---
title: مدیریت جداول ارائه در JavaScript
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/nodejs-java/manage-table/
keywords:
- اضافه کردن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- تراز کردن متن
- قالب‌بندی متن
- استایل جدول
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با JavaScript و Aspose.Slides برای Node.js. مثال‌های کد ساده‌ای را کشف کنید تا گردش کار جداول خود را بهینه کنید."
---
## **معرفی**

یک جدول در PowerPoint روشی کارآمد برای نمایش و به تصویر کشیدن اطلاعات است. اطلاعات در یک شبکهٔ سلول‌ها (چیدمان شده در ردیف‌ها و ستون‌ها) ساده و به راحتی قابل درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table)، کلاس [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) و انواع دیگر را ارائه می‌دهد تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک آرایهٔ `columnWidth` تعریف کنید.  
4. یک آرایهٔ `rowHeight` تعریف کنید.  
5. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) به اسلاید اضافه کنید.  
6. برای هر [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) تکرار کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.  
7. دو سلول اول ردیف اول جدول را ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) یک [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید.  
10. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک جدول در یک ارائه ایجاد کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // یک شکل جدول را به اسلاید اضافه می‌کند
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // سلول‌های ۱ و ۲ ردیف ۱ را ادغام می‌کند
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // متنی به سلول ادغام‌شده اضافه می‌کند
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و صفر‑پایه است. اولین سلول در جدول به صورت 0,0 (ستون 0، ردیف 0) ایندکس می‌شود.

به عنوان مثال، سلول‌های یک جدول با ۴ ستون و ۴ ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد JavaScript نشان می‌دهد چگونه شماره‌گذاری سلول‌های یک جدول را مشخص کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // یک شکل جدول را به اسلاید اضافه می‌کند
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // قالب حاشیه را برای هر سلول تنظیم می‌کند
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید حاوی جدول را از طریق ایندکس آن به دست آورید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) ایجاد کنید و آن را به null تنظیم کنید.  
4. در تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) تکرار کنید تا جدول یافت شود.  

   اگر گمان می‌کنید اسلاید مورد نظر فقط یک جدول دارد، می‌توانید تمام اشکال موجود را بررسی کنید. وقتی شکلی به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) تبدیل کنید. اما اگر اسلاید حاوی چند جدول باشد، بهتر است جدول مورد نیاز را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) جستجو کنید.  

5. از شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) برای کار با جدول استفاده کنید. در مثال زیر، یک ردیف جدید به جدول اضافه کردیم.  
6. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه به یک جدول موجود دسترسی پیدا کرده و با آن کار کنید:

```javascript
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // TableEx را به null مقداردهی می‌کند
    var tbl = null;
    // در میان اشکال تکرار می‌کند و مرجع جدول یافت‌شده را تنظیم می‌کند
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // متن را برای اولین ستون ردیف دوم تنظیم می‌کند
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // ارائه تغییر یافته را روی دیسک ذخیره می‌کند
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تراز کردن متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را به اسلاید اضافه کنید.  
4. به شیء [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) از جدول دسترسی پیدا کنید.  
5. به [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) مربوط به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی تراز کنید.  
7. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه متن داخل یک جدول را تراز کنید:

```javascript
// یک نمونه از کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // شکل جدول را به اسلاید اضافه می‌کند
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // به فریم متن دسترسی پیدا می‌کند
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // شیء Paragraph را برای فریم متن ایجاد می‌کند
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // شیء Portion را برای پاراگراف ایجاد می‌کند
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // متن را به صورت عمودی تراز می‌کند
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به دست آورید.  
3. به شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) از اسلاید دسترسی پیدا کنید.  
4. برای متن، متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) را تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) را تنظیم کنید.  
7. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه گزینه‌های قالب‌بندی دلخواه خود را بر متن داخل یک جدول اعمال کنید:

```javascript
// یک نمونه از کلاس Presentation را ایجاد می‌کند
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // فرض می‌کنیم که اولین شکل در اولین اسلاید یک جدول است
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // تراز متن سلول‌های جدول و حاشیهٔ راست را در یک فراخوانی تنظیم می‌کند
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // نوع متن عمودی سلول‌های جدول را تنظیم می‌کند
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های سبک یک جدول را بازیابی کنید تا بتوانید این جزئیات را برای جدول دیگری یا مکان دیگری استفاده کنید. این کد JavaScript نشان می‌دهد چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// قالب پیش‌فرض استایل را تغییر می‌دهد
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی [**setAspectRatioLocked**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) را فراهم کرده تا بتوانید تنظیم قفل نسبت ابعاد را برای جداول و سایر اشکال اعمال کنید.

این کد JavaScript نشان می‌دهد چگونه نسبت ابعاد یک جدول را قفل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// معکوس
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم جهت خواندن از راست به چپ (RTL) را برای کل جدول و متن داخل سلول‌ها فعال کنم؟**  

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/setrighttoleft/) را ارائه می‌دهد و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) دارند. استفاده از هر دو روش اطمینان می‌دهد که ترتیب RTL صحیح باشد و رندرینگ داخل سلول‌ها به درستی انجام شود.

**چگونه می‌توانم از جابه‌جایی یا تغییر اندازه جدول توسط کاربران در فایل نهایی جلوگیری کنم؟**  

از قفل‌های شکل استفاده کنید تا جابه‌جایی، تغییر اندازه، انتخاب و ... غیرفعال شود. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**  

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر به‌صورت کشیده‌شده یا کاشی‌مانند ناحیهٔ سلول را پوشش می‌دهد.