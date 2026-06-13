---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint در اندروید
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/androidjava/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- اولین ردیف
- سرعنوان جدول
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
- Android
- Java
- Aspose.Slides
description: "مدیریت ردیف‌ها و ستون‌های جدول در PowerPoint با Aspose.Slides برای اندروید از طریق Java و تسریع ویرایش ارائه و به‌روزرسانی داده‌ها."
---
## **مقدمه**

برای این که بتوانید ردیف‌ها و ستون‌های یک جدول را در یک ارائه PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/table/)، رابط [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) و انواع دیگر بسیاری را فراهم می‌کند.

## **تنظیم ردیف اول به عنوان سرعنوان**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) ایجاد کنید و آن را به null تنظیم کنید.  
4. از میان تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) عبور کنید تا جدول مربوطه را پیدا کنید.  
5. ردیف اول جدول را به عنوان سرعنوان تنظیم کنید.  

این کد Java نشان می‌دهد چگونه ردیف اول یک جدول را به عنوان سرعنوان تنظیم کنید:

```java
// کلاس Presentation را نمونه‌سازی می‌کند
Presentation pres = new Presentation("table.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // متغیر TableEx را به null مقداردهی می‌کند
    ITable tbl = null;

    // از طریق اشکال عبور می‌کند و مرجع جدول را تنظیم می‌کند
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // ردیف اول جدول را به عنوان سرعنوان تنظیم می‌کند
            tbl.setFirstRow(true);
        }
    }
    
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **کلون کردن ردیف یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) را به اسلاید اضافه کنید از طریق متد [addTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. ردیف جدول را کلون کنید.  
7. ستون جدول را کلون کنید.  
8. ارائه اصلاح شده را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه ردیف یا ستون یک جدول PowerPoint را کلون کنید:

```java
 // کلاس Presentation را نمونه‌سازی می‌کند
Presentation pres = new Presentation("Test.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // ستون‌ها را با عرض و ردیف‌ها را با ارتفاع تعریف می‌کند
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // یک شکل جدول را به اسلاید اضافه می‌کند
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // متن را به سلول 1 ردیف 1 اضافه می‌کند
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // متن را به سلول 2 ردیف 1 اضافه می‌کند
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // ردیف 1 را در انتهای جدول کلون می‌کند
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // متن را به سلول 1 ردیف 2 اضافه می‌کند
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // متن را به سلول 2 ردیف 2 اضافه می‌کند
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // ردیف 2 را به عنوان ردیف چهارم جدول کلون می‌کند
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // ستون اول را در انتها کلون می‌کند
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // ستون دوم را در ایندکس ستون چهارم کلون می‌کند
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف ردیف یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) را به اسلاید اضافه کنید از طریق متد [addTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. ردیف جدول را حذف کنید.  
7. ستون جدول را حذف کنید.  
8. ارائه اصلاح شده را ذخیره کنید.  

این کد Java نشان می‌دهد چگونه یک ردیف یا ستون را از جدول حذف کنید:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ردیف جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. به شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) مربوطه از اسلاید دسترسی پیدا کنید.  
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ردیف اول تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را برای سلول‌های ردیف اول تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ردیف دوم تنظیم کنید.  
7. ارائه اصلاح شده را ذخیره کنید.  

این کد Java عمل را نشان می‌دهد.

```java
// یک نمونه از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // ارتفاع فونت سلول‌های ردیف اول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // تراز متن و حاشیه راست سلول‌های ردیف اول را تنظیم می‌کند
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // نوع عمودی متن سلول‌های ردیف دوم را تنظیم می‌کند
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید،  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. به شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) مربوطه از اسلاید دسترسی پیدا کنید.  
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ستون اول تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را برای سلول‌های ستون اول تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ستون دوم تنظیم کنید.  
7. ارائه اصلاح شده را ذخیره کنید.  

این کد Java عمل را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // ارتفاع فونت سلول‌های ستون اول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // تراز متن و حاشیه راست سلول‌های ستون اول را در یک فراخوانی تنظیم می‌کند
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // نوع عمودی متن سلول‌های ستون دوم را تنظیم می‌کند
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگری یا در جای دیگری استفاده کنید. این کد Java نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغییر تم پیش‌فرض پیش‌تنظیم سبک
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم تم/سبک‌های PowerPoint را به جدولی که قبلاً ایجاد شده اعمال کنم؟**  
بله. جدول تم اسلاید/چینش/مستر را به ارث می‌برد و می‌توانید در بالای آن تم پر کردن‌ها، حاشیه‌ها و رنگ‌های متن را بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را همانند Excel مرتب کنم؟**  
نه، جداول Aspose.Slides قابلیت مرتب‌سازی یا فیلترهای داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید، سپس ردیف‌های جدول را براساس آن ترتیب پر کنید.

**آیا می‌توانم ستون‌های نوار دار (خط‌دار) داشته باشم در حالی که رنگ‌های سفارشی برای سلول‌های خاص حفظ شوند؟**  
بله. ستون‌های نوار دار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول نسبت به سبک جدول اولویت دارد.