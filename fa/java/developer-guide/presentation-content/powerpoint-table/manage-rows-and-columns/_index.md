---
title: مدیریت ردیف‌ها و ستون‌ها در جداول PowerPoint با استفاده از Java
linktitle: ردیف‌ها و ستون‌ها
type: docs
weight: 20
url: /fa/java/manage-rows-and-columns/
keywords:
- ردیف جدول
- ستون جدول
- اولین ردیف
- سرتیتر جدول
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
- Java
- Aspose.Slides
description: "با Aspose.Slides برای Java، ردیف‌ها و ستون‌های جدول را در PowerPoint مدیریت کنید و ویرایش ارائه و به‌روزرسانی داده‌ها را سرعت دهید."
---
## **مقدمه**

برای این که بتوانید ردیف‌ها و ستون‌های یک جدول را در ارائهٔ PowerPoint مدیریت کنید، Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/table/)، رابط [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) و انواع دیگر را فراهم می‌کند. 

## **تنظیم ردیف اول به‌عنوان سرصفحه**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید. 
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) ایجاد کنید و آن را null تنظیم کنید. 
4. تمام اشیای [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را پیمایش کنید تا جدول مرتبط را پیدا کنید. 
5. ردیف اول جدول را به‌عنوان سرصفحه تنظیم کنید. 

این کد جاوا نشان می‌دهد چگونه ردیف اول جدول را به‌عنوان سرصفحه تنظیم کنید:

```java
//نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // متغیر TableEx را به null مقداردهی می‌کند
    ITable tbl = null;

    // از اشکال عبور می‌کند و مرجع جدول را تنظیم می‌نماید
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //ردیف اول جدول را به عنوان سرصفحه آن تنظیم می‌کند
            tbl.setFirstRow(true);
        }
    }
    
    // ذخیرهٔ ارائه بر روی دیسک
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **کلون کردن ردیف یا ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید، 
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. آرایه‌ای از `columnWidth` تعریف کنید. 
4. آرایه‌ای از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را از طریق متد [addTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) به اسلاید اضافه کنید. 
6. ردیف جدول را کلون کنید. 
7. ستون جدول را کلون کنید. 
8. ارائهٔ اصلاح‌شده را ذخیره کنید. 

این کد جاوا نشان می‌دهد چگونه ردیف یا ستون جدول PowerPoint را کلون کنید:

```java
 // نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // دسترسی به اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // تعریف ستون‌ها با عرض‌ها و ردیف‌ها با ارتفاع‌ها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // افزودن شکل جدول به اسلاید
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // افزودن متن به سلول 1 ردیف 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // افزودن متن به سلول 2 ردیف 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // کلون ردیف 1 در انتهای جدول
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // افزودن متن به سلول 1 ردیف 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // افزودن متن به سلول 2 ردیف 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // کلون ردیف 2 به عنوان ردیف چهارم جدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // کلون اولین ستون در انتها
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // کلون ستون دوم در شاخص ستون چهارم
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // ذخیرهٔ ارائه بر روی دیسک
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف ردیف یا ستون از جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید، 
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. آرایه‌ای از `columnWidth` تعریف کنید. 
4. آرایه‌ای از `rowHeight` تعریف کنید. 
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) را از طریق متد [addTable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) به اسلاید اضافه کنید. 
6. ردیف جدول را حذف کنید. 
7. ستون جدول را حذف کنید. 
8. ارائهٔ اصلاح‌شده را ذخیره کنید. 

این کد جاوا نشان می‌دهد چگونه ردیف یا ستون را از جدول حذف کنید:

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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید، 
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) مرتبط را از اسلاید دریافت کنید. 
4. مقدار [setFontHeight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ردیف اول تنظیم کنید. 
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را برای سلول‌های ردیف اول تنظیم کنید. 
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ردیف دوم تنظیم کنید. 
7. ارائهٔ اصلاح‌شده را ذخیره کنید. 

این کد جاوا این عملیات را نشان می‌دهد.

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // تنظیم ارتفاع فونت سلول‌های ردیف اول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // تنظیم تراز متن سلول‌های ردیف اول و حاشیه راست
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // تنظیم نوع عمودی متن سلول‌های ردیف دوم
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // ذخیرهٔ ارائه بر روی دیسک
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح ستون جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه را بارگذاری کنید، 
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. شیء [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) مرتبط را از اسلاید دریافت کنید. 
4. مقدار [setFontHeight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای سلول‌های ستون اول تنظیم کنید. 
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را برای سلول‌های ستون اول تنظیم کنید. 
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را برای سلول‌های ستون دوم تنظیم کنید. 
7. ارائهٔ اصلاح‌شده را ذخیره کنید. 

این کد جاوا این عملیات را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // ارتفاع فونت سلول‌های ستون اول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // تراز متن سلول‌های ستون اول و حاشیه راست را در یک فراخوانی تنظیم می‌کند
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

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگر یا مکان دیگری استفاده کنید. این کد جاوا نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌تنظیم شدهٔ جدول دریافت کنید:

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

**آیا می‌توانم تم‌ها/سبک‌های PowerPoint را به جدول موجود اعمال کنم؟**

بله. جدول تم اسلاید/چیدمان/مستری را به ارث می‌برد و همچنان می‌توانید پر کردن‌ها، حاشیه‌ها و رنگ‌های متن را روی آن تم بازنویسی کنید.

**آیا می‌توانم ردیف‌های جدول را مانند Excel مرتب کنم؟**

خیر، جدول‌های Aspose.Slides قابلیت مرتب‌سازی یا فیلتر داخلی ندارند. ابتدا داده‌ها را در حافظه مرتب کنید و سپس ردیف‌های جدول را به ترتیب جدید پر کنید.

**آیا می‌توانم ستون‌های نوار دار (راه‌راه) داشته باشم در حالی که رنگ‌های سفارشی را برای سلول‌های خاص نگه دارم؟**

بله. ستون‌های نوار دار را فعال کنید، سپس سلول‌های خاص را با قالب‌بندی محلی بازنویسی کنید؛ قالب‌بندی سطح سلول بر سبک جدول اولویت دارد.