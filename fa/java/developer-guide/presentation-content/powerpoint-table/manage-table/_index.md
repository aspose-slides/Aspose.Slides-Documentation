---
title: مدیریت جداول ارائه در Java
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت عرض به ارتفاع
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای Java. مثال‌های کد ساده‌ای را کشف کنید تا گردش کار جداول خود را بهینه‌سازی کنید."
---
## **معرفی**

یک جدول در PowerPoint روشی کارآمد برای نمایش و انتقال اطلاعات است. اطلاعات در یک شبکه‌ی سلول‌ها (مرتب شده در ردیف‌ها و ستون‌ها) ساده و به‌سادگی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Table)، اینترفیس [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable)، کلاس [Cell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cell/)، اینترفیس [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) و سایر انواع را فراهم می‌کند تا به شما امکان ایجاد، به‌روزرسانی و مدیریت جداول در انواع ارائه‌ها را بدهد.

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک آرایه‌ی `columnWidth` تعریف کنید.  
4. یک آرایه‌ی `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را به اسلاید از طریق متد [addTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) اضافه کنید.  
6. بر هر [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) پیمایش کنید تا قالب‌بندی را بر روی حاشیه‌های بالا، پایین، راست و چپ اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. دسترسی به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) یک [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) را داشته باشید.  
9. متنی را به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) اضافه کنید.  
10. ارائه‌ی اصلاح‌شده را ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // سلول‌های ۱ و ۲ ردیف ۱ را ادغام می‌کند
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // متن‌ای به سلول ادغام‌شده اضافه می‌کند
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // ارائه را در دیسک ذخیره می‌کند
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و از صفر شروع می‌شود. اولین سلول جدول با اندیس 0,0 (ستون 0، ردیف 0) مشخص می‌شود.

به عنوان مثال، سلول‌های یک جدول با ۴ ستون و ۴ ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به یک جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. از طریق اندیس، مرجع اسلایدی که شامل جدول است را دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) ایجاد کنید و آن را برابر null تنظیم کنید.  
4. از میان تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) تا زمان پیدا کردن جدول پیمایش کنید.  

   اگر فکر می‌کنید اسلاید موردنظر تنها یک جدول دارد، می‌توانید به سادگی همهٔ اشکال موجود در آن را بررسی کنید. وقتی شکلی به‌عنوان جدول شناسایی شد، می‌توانید آن را به‌عنوان شیء [Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Table) تبدیل کنید. اما اگر اسلاید شامل چندین جدول باشد، بهتر است جدول موردنیاز را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) جستجو کنید.  

5. از شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) برای کار با جدول استفاده کنید. در مثال زیر، یک ردیف جدید به جدول اضافه کردیم.  
6. ارائه‌ی اصلاح‌شده را ذخیره کنید.

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // مقداردهی اولیه null برای TableEx
    ITable tbl = null;

    // از اشکال پیمایش می‌کند و مرجعی به جدول پیدا شده تنظیم می‌کند
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // متن را برای ستون اول ردیف دوم تنظیم می‌کند
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // ارائهٔ اصلاح‌شده را روی دیسک ذخیره می‌کند
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **یافتن سلولی که TextFrame را در اختیار دارد**

هنگامی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را از یک جدول دریافت می‌کند، از متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) برای بازیابی [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) مالک استفاده کنید. برای یک TextFrame سلول جدول، [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) مالک را بر می‌گرداند و [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) مقدار `null` را بر می‌گرداند، حتی اگر جدول خود یک شکل باشد.

مختصات سلول‌ها از طریق متدهای فقط‌خواندنی [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/#getFirstColumnIndex--) و [ICell.getFirstRowIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/#getFirstRowIndex--) در دسترس هستند. همچنین [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) ناوبری فقط‌خواندنی فراهم می‌کند: مالک را بر می‌گرداند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، مقدار برگشتی را برای `null` بررسی کنید.

برای مشاهده مثال کامل که مالکیت سلول جدول و شکل را شناسایی می‌کند، به [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **ترازبندی متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را به اسلاید اضافه کنید.  
4. از جدول یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) بدست آورید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی ترازبندی کنید.  
7. ارائه‌ی اصلاح‌شده را ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // به فریم متن دسترسی پیدا می‌کند
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // شیء Paragraph را برای فریم متن ایجاد می‌کند
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // شیء Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // متن را به صورت عمودی ترازبندی می‌کند
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. از اسلاید یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) بدست آورید.  
4. برای متن، متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) را تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را تنظیم کنید.  
7. ارائه‌ی اصلاح‌شده را ذخیره کنید.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("simpletable.pptx");
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // ترازبندی متن سلول‌های جدول و حاشیهٔ راست را در یک فراخوانی تنظیم می‌کند
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید آن جزئیات را برای جدول دیگر یا مکان دیگری استفاده کنید. این کد Java نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌تنظیم شده جدول دریافت کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغییر تم پیش‌فرض پیش‌تنظیم سبک

    // پیش‌تنظیم سبک جدول را دریافت می‌کند
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // پیش‌تنظیم سبک بازیابی‌شده را به جدول دیگری اعمال می‌کند
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی [**setAspectRatioLocked**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) را فراهم کرده است تا بتوانید قفل نسبت ابعاد را برای جداول و سایر شکل‌ها اعمال کنید.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // معکوس

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم جهت خواندن راست‌به‌چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**  

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/table/#setRightToLeft-boolean-) را در اختیار می‌گذارد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) را دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب و رندر صحیح RTL در داخل سلول‌ها برقرار باشد.

**چگونه می‌توانم از جابجا یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**  

از [shape locks](/slides/fa/java/applying-protection-to-presentation/) استفاده کنید تا جابجایی، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا درج تصویر در داخل سلول به‌عنوان پس‌زمینه پشتیبانی می‌شود؟**  

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشیدگی یا کاشی) کل فضای سلول را می‌پوشاند.