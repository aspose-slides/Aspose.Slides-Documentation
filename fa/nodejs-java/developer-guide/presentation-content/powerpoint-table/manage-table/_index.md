---
title: مدیریت جدول‌های ارائه در جاوا اسکریپت
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/nodejs-java/manage-table/
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
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "ایجاد و ویرایش جدول‌ها در اسلایدهای PowerPoint با استفاده از جاوا اسکریپت و Aspose.Slides برای Node.js. مثال‌های ساده کد را برای بهینه‌سازی گردش کار جدول‌ها کشف کنید."
---
## **مقدمه**

یک جدول در PowerPoint روشی کارآمد برای نمایش و به تصویر کشیدن اطلاعات است. اطلاعات در یک شبکه از سلول‌ها (که به صورت ردیف و ستون چیده شده‌اند) ساده و آسان برای درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) ، کلاس [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) و انواع دیگر را فراهم می‌کند تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک آرایه از `columnWidth` تعریف کنید.  
4. یک آرایه از `rowHeight` تعریف کنید.  
5. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را به اسلاید اضافه کنید با استفاده از متد [addTable](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).  
6. در هر [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) پیمایش کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.  
7. چهار سلول در گوشه بالای چپ جدول (دو ستون اول دو ردیف اول) را در یک سلول واحد ادغام کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) یک [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید.  
10. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه یک جدول در یک ارائه ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
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
    // بلاک ۲×۲ سلول‌های گوشهٔ بالا‑چپ را در یک سلول ادغام می‌کند
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

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و صفر‑مبتنی است. اولین سلول در جدول با ایندکس 0,0 (ستون 0، ردیف 0) شناخته می‌شود.  

به عنوان مثال، سلول‌های یک جدول با ۴ ستون و ۴ ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد JavaScript نشان می‌دهد که چگونه شماره‌گذاری سلول‌ها در یک جدول را مشخص کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
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

## **دسترس به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید حاوی جدول را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) ایجاد کنید و آن را به null تنظیم کنید.  
4. در تمام اشیای [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) پیمایش کنید تا جدول یافت شود.  
   اگر گمان می‌کنید اسلاید مورد نظر تنها یک جدول دارد، می‌توانید به سادگی تمام شکل‌های آن را بررسی کنید. هنگامی که یک شکل به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) تبدیل (typecast) کنید. اما اگر اسلاید شامل چند جدول باشد، بهتر است جدول مورد نیاز را از طریق متد [setAlternativeText(String value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) جستجو کنید.  
5. از شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) برای کار با جدول استفاده کنید. در مثال زیر، متن یک سلول در جدول را تنظیم می‌کنیم.  
6. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه به یک جدول موجود دسترسی پیدا کنید و با آن کار کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // اسلاید اول را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // TableEx را به مقدار null مقداردهی می‌کند
    var tbl = null;
    // در میان اشکال پیمایش می‌کند و مرجع جدول یافت‌شده را تنظیم می‌کند
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // متن ستون اول ردیف دوم را تنظیم می‌کند
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // ارائهٔ تغییر یافته را روی دیسک ذخیره می‌کند
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **یافتن سلولی که فریم متن را دارد**

هنگامی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را از یک جدول دریافت می‌کند، از متد [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) برای بازیابی [Cell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/) مالک استفاده کنید. برای یک فریم متن سلول‑جدول، [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) مالک را برمی‌گرداند و [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentShape--) مقدار `null` برمی‌گرداند، حتی اگر خود جدول یک شکل باشد.  

مختصات سلول‌ها از طریق متدهای فقط‑خواندنی [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) در دسترس است. متد [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) همچنین ناوبری فقط‑خواندنی را فراهم می‌کند: مالک را برمی‌گرداند ولی مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، سلول بازگشتی را برای `null` بررسی کنید.  

برای یک مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکالی که به نودهای SmartArt مرتبط هستند، به [Search and Replace Text](/slides/fa/nodejs-java/search-and-replace-text/) مراجعه کنید.

## **چینش متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را به اسلاید اضافه کنید.  
4. یک شیء [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را از جدول دسترسی پیدا کنید.  
5. به [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) متعلق به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) دسترسی پیدا کنید.  
6. متن را به صورت عمودی چینش کنید.  
7. ارائهٔ تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد که چگونه متن را در یک جدول چینش کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اسلاید اول را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // شِکل جدول را به اسلاید اضافه می‌کند
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // فریم متن را دریافت می‌کند
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
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
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
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Table) را از اسلاید دسترسی پیدا کنید.  
4. برای متن، متد [setFontHeight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) را تنظیم کنید.  
5. متدهای [setAlignment(int value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) را تنظیم کنید.  
6. متد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) را تنظیم کنید.  
7. ارائهٔ تغییر یافته را ذخیره کنید.  

این کد JavaScript نشان می‌دهد که چگونه گزینه‌های قالب‌بندی دلخواه خود را بر روی متن در یک جدول اعمال کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ارتفاع قلم سلول‌های جدول را تنظیم می‌کند
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // ترازبندی متن سلول‌های جدول و حاشیهٔ راست را در یک فراخوانی تنظیم می‌کند
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // نوع عمودی متن سلول‌های جدول را تنظیم می‌کند
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم پیش‌فرض سبک جدول**

Aspose.Slides سبک‌های داخلی جدول PowerPoint را به عنوان شمارش‌گر [TableStylePreset](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tablestylepreset/) فراهم می‌کند، بنابراین می‌توانید همان ظاهر را به هر جدول اعمال کنید. این کد JavaScript نشان می‌دهد که چگونه سبک پیش‌فرض یک جدول را با یک سبک پیش‌فرض دیگر جایگزین کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// قالب پیش‌فرض سبک را تغییر می‌دهد
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک شکل هندسی نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides خصوصیت [**setAspectRatioLocked**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) را فراهم کرده تا بتوانید تنظیم نسبت ابعاد جدول‌ها و سایر شکل‌ها را قفل کنید.

این کد JavaScript نشان می‌دهد که چگونه نسبت ابعاد یک جدول را قفل کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**  
بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/setrighttoleft/) را فراهم می‌کند و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) را دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL درست و رندر مناسب در داخل سلول‌ها انجام شود.

**چگونه می‌توانم مانع حرکت یا تغییر اندازه جدول در فایل نهایی توسط کاربران شوم؟**  
از قفل‌های شکل استفاده کنید تا حرکت، تغییر اندازه، انتخاب و غیره غیرفعال شوند. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا وارد کردن تصویر به عنوان پس‌زمینه در داخل یک سلول پشتیبانی می‌شود؟**  
بله. می‌توانید برای یک سلول پرکنش تصویر ([picture fill](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/)) تنظیم کنید؛ تصویر بر اساس حالت انتخابی (کشیدگی یا موزاییک) ناحیه سلول را پوشش می‌دهد.