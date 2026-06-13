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
- نسبت ابعاد
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای Java. مثال‌های ساده کدنویسی را کشف کنید تا جریان کاری جداول خود را بهبود بخشید."
---
## **مقدمه**

یک جدول در PowerPoint یک روش کارآمد برای نمایش و بیان اطلاعات است. اطلاعات در یک شبکه‌ی سلول‌ها (آرایه‌بندی شده به صورت ردیف‌ها و ستون‌ها) ساده و به راحتی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Table)، رابط [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable)، کلاس [Cell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/cell/)، رابط [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) و انواع دیگری را ارائه می‌دهد تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید. 

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) به اسلاید اضافه کنید.  
6. در هر [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) پیمایش کنید تا قالب‌بندی مرزهای بالا، پایین، راست و چپ را اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. دسترسی به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) یک [ICell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/) داشته باشید.  
9. متن دلخواهی را به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) اضافه کنید.  
10. ارائه‌ی تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک جدول در یک ارائه ایجاد کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // فرمت حاشیه را برای هر سلول تنظیم می‌کند
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // متن‌ای به سلول ادغام‌شده اضافه می‌کند
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و مبتنی بر صفر است. اولین سلول در یک جدول به عنوان 0,0 (ستون 0، ردیف 0) اندیس‌گذاری می‌شود. 

به عنوان مثال، سلول‌های یک جدول با ۴ ستون و ۴ ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد Java نشان می‌دهد چگونه شماره‌گذاری سلول‌های یک جدول را مشخص کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // فرمت حاشیه را برای هر سلول تنظیم می‌کند
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

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید حاوی جدول را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) ایجاد کنید و آن را به null تنظیم کنید.  
4. در تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) تا پیدا شدن جدول پیمایش کنید.  
   
   اگر شک دارید اسلایدی که با آن کار می‌کنید تنها یک جدول دارد، می‌توانید به سادگی تمام شکل‌های موجود در آن را بررسی کنید. وقتی یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Table) تبدیل کنید. اما اگر اسلاید چندین جدول داشته باشد، بهتر است جدول موردنظرتان را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) جستجو کنید.  
5. از شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) برای کار با جدول استفاده کنید. در مثال زیر یک ردیف جدید به جدول اضافه شد.  
6. ارائه‌ی تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه به یک جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // به اولین اسلاید دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // متغیر TableEx را با مقدار null مقداردهی می‌کند
    ITable tbl = null;

    // از میان اشکال عبور می‌کند و مرجعی به جدول یافت‌شده تنظیم می‌کند
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // متن را برای ستون اول ردیف دوم تنظیم می‌کند
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // ارائه اصلاح‌شده را در دیسک ذخیره می‌کند
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تراز متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را به اسلاید اضافه کنید.  
4. از جدول یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) دسترسی پیدا کنید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) در [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی تراز کنید.  
7. ارائه‌ی تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه متن را در یک جدول تراز کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند
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
    
    // به فریم متن دسترسی می‌یابد
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // شی Paragraph را برای فریم متن ایجاد می‌کند
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // شی Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // متن را به صورت عمودی تراز می‌کند
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
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. از اسلاید یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) دسترسی پیدا کنید.  
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای متن تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را تنظیم کنید.  
7. ارائه‌ی تغییر یافته را ذخیره کنید. 

این کد Java نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را بر متن در جدول اعمال کنید:

```java
// یک شی از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("simpletable.pptx");
try {
    // فرض می‌کنیم اولین شکل در اولین اسلاید جدول است
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // تراز متن سلول‌های جدول و حاشیه راست را در یک فراخوانی تنظیم می‌کند
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

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگر یا جای دیگری استفاده کنید. این کد Java نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌تنظیم جدول دریافت کنید:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تم پیش‌تنظیم سبک پیش‌فرض را تغییر می‌دهد
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **قفل کردن نسبت عرض به طول جدول**

نسبت عرض به طول یک شکل هندسی نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی [**setAspectRatioLocked**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) را برای قفل کردن تنظیم نسبت عرض به طول برای جداول و سایر شکل‌ها فراهم کرده است. 

این کد Java نشان می‌دهد چگونه نسبت عرض به طول یک جدول را قفل کنید:

```java
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

## **سؤال‌های متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای یک جدول کامل و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/table/#setRightToLeft-boolean-) را در اختیار می‌گذارد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب و رندر RTL به‌درستی در داخل سلول‌ها اعمال می‌شود.

**چگونه می‌توانم از جابه‌جایی یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**

از [قفل‌های شکل](/slides/fa/java/applying-protection-to-presentation/) استفاده کنید تا جابه‌جایی، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها بر جدول‌ها نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول از [picture fill](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillformat/) استفاده کنید؛ تصویر بر اساس حالت انتخابی (کشیده شدن یا کاشی) کل فضای سلول را پوشش می‌دهد.