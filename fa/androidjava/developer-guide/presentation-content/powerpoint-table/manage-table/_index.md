---
title: مدیریت جداول ارائه در اندروید
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/androidjava/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- هم‌راستا کردن متن
- قالب‌بندی متن
- سبک جدول
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ساخت و ویرایش جداول در اسلایدهای پاورپوینت با Aspose.Slides برای اندروید. مثال‌های ساده کد جاوا را کشف کنید تا فرآیندهای کاری جدول خود را روان‌سازی کنید."
---
## **مقدمه**

یک جدول در PowerPoint روشی کارآمد برای نمایش و ارائه اطلاعات است. اطلاعات در یک شبکه سلول‌ها (که به صورت سطرها و ستون‌ها چیده شده‌اند) ساده و به راحتی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Table)، اینترفیس [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable)، کلاس [Cell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/cell/)، اینترفیس [ICell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در تمامی انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از صفر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) را با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) به اسلاید اضافه کنید.  
6. در هر [ICell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/) پیمایش کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) مربوط به یک [ICell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) اضافه کنید.  
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک جدول را در یک ارائه ایجاد کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
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

    // متنی به سلول ادغام‌شده اضافه می‌کند
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و بر پایه‌ی صفر است. اولین سلول در جدول به صورت 0,0 (ستون 0، ردیف 0) شناخته می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد Java نشان می‌دهد چگونه شماره‌گذاری سلول‌ها در یک جدول را مشخص کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
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

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترس‌به‌جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلایدی که جدول را شامل می‌شود از طریق ایندکس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) ایجاد کنید و آن را به null تنظیم کنید.  
4. در تمام اشیاء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) پیمایش کنید تا جدول یافت شود.

اگر شک دارید اسلایدی که با آن کار می‌کنید فقط یک جدول دارد، می‌توانید به سادگی تمام اشکالی که شامل می‌شود را بررسی کنید. وقتی یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Table) تبدیل کنید. اما اگر اسلاید چندین جدول دارد، بهتر است جدول مورد نیاز را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) جستجو کنید.  
5. از شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) برای کار با جدول استفاده کنید. در مثال زیر، متن یک سلول در جدول را تنظیم می‌کنیم.  
6. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه به جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // به اسلاید اول دسترسی می‌یابد
    ISlide sld = pres.getSlides().get_Item(0);

    // مقدار TableEx را به null مقداردهی می‌کند
    ITable tbl = null;

    // در میان شکل‌ها پیمایش می‌کند و به جدول پیدا شده یک مرجع می‌دهد
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // متن را برای ستون اول ردیف دوم تنظیم می‌کند
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // ارائه اصلاح‌شده را روی دیسک ذخیره می‌کند
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **یافتن سلولی که چارچوب متن (Text Frame) را مالک است**

زمانی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را از جدول دریافت می‌کند، از متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) برای بازیابی [ICell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/) مالک استفاده کنید. برای چارچوب متن سلول جدول، [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) مالک را برمی‌گرداند و [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentShape--) مقدار `null` می‌دهد، حتی اگر خود جدول یک شکل باشد.

مختصات سلول از طریق متدهای فقط‑خواندنی [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) و [ICell.getFirstRowIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) در دسترس است. همچنین [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) ناوبری فقط‑خواندنی فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، سلول برگشت داده‌شده را برای `null` بررسی کنید.

برای مثال کامل که مالک سلول جدول و شکل را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به [Search and Replace Text](/slides/fa/androidjava/search-and-replace-text/) مراجعه کنید.

## **هم‌راستا کردن متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) را به اسلاید اضافه کنید.  
4. از جدول یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) دریافت کنید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی هم‌راستا کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه متن را در یک جدول هم‌راستا کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // شکل جدول را به اسلاید اضافه می‌کند
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // به چارچوب متن دسترسی می‌یابد
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // شیء Paragraph را برای چارچوب متن ایجاد می‌کند
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // شیء Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // متن را به صورت عمودی هم‌راستا می‌کند
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. از یک شیء [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) در اسلاید دسترسی پیدا کنید.  
4. متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) را برای متن تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) را تنظیم کنید.  
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه گزینه‌های قالب‌بندی مورد نظر خود را بر روی متن در جدول اعمال کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("simpletable.pptx");
try {
    // فرض می‌کنیم اولین شکل در اسلاید اول یک جدول است
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // تنظیم هم‌راستایی متن سلول‌های جدول و حاشیه راست در یک فراخوانی
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

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگری یا مکان دیگری استفاده کنید. این کد Java نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // قالب پیش‌تنظیم پیش‌فرض سبک را تغییر می‌دهد

    // دریافت پیش‌تنظیم سبک جدول
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // اعمال پیش‌تنظیم سبک بازیابی‌شده بر جدول دیگری
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **قفل کردن نسبت ارتفاع به عرض جدول**

نسبت طول به عرض یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی [**setAspectRatioLocked**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) را فراهم کرده تا بتوانید تنظیم نسبت طول به عرض را برای جداول و سایر اشکال قفل کنید.

این کد Java نشان می‌دهد چگونه نسبت طول به عرض یک جدول را قفل کنید:

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

## **سوالات متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای کل جدول و متن در سلول‌های آن فعال کنم؟**  
بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) را ارائه می‌دهد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) را دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب و رندر RTL به‌درستی داخل سلول‌ها اعمال می‌شود.

**چگونه می‌توانم جلوگیری کنم که کاربران جدول را در فایل نهایی منتقل یا اندازه‌اش را تغییر دهند؟**  
از قفل‌های شکل استفاده کنید تا جابه‌جایی، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا درج تصویر به عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**  
بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر به‌تناسب حالت انتخابی (کشیده یا کاشی) ناحیه سلول را پوشش می‌دهد.