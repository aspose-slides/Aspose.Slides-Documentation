---
title: مدیریت جدول‌های ارائه در JavaScript
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/nodejs-java/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت طول به عرض
- تراز متن
- قالب‌بندی متن
- سبک جدول
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و ویرایش جدول‌ها در اسلایدهای PowerPoint با JavaScript و Aspose.Slides برای Node.js. نمونه‌های کد ساده را برای بهبود گردش کار جدول‌های خود کشف کنید."
---
## **مقدمه**

جدول‌ها در PowerPoint اطلاعات را به صورت ردیف و ستون سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس‌های [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)، [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) و انواع دیگر را ارائه می‌دهد تا بتوانید جدول‌ها را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد جدول از صفر**

یک جدول را با تعیین موقعیت، عرض ستون‌ها و ارتفاع ردیف‌ها ایجاد کنید. پس از افزودن آن به یک اسلاید، می‌توانید حاشیه‌های سلول‌ها را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را بر حسب اندیس آن دریافت کنید.
3. آرایه‌ای از عرض ستون‌ها بر حسب پوینت تعریف کنید.
4. آرایه‌ای از ارتفاع ردیف‌ها بر حسب پوینت تعریف کنید.
5. یک شیء [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) را از طریق متد [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) به اسلاید اضافه کنید.
6. برای هر [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) مرزی‌های بالا، پایین، راست و چپ را قالب‌بندی کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. از طریق متد [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) به سلول ادغام‌شده دسترسی پیدا کنید.
9. متن را در سلول ادغام‌شده تنظیم کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر جدولی با سه ستون و پنج ردیف در نقطه‌های (100, 50) ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 پوینت اعمال می‌شود، دو سلول اول ردیف اول ادغام می‌شوند و نتیجه به صورت `table.pptx` ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، اندیس‌های سلول صفر-محور هستند و به ترتیب (ستون، ردیف) استفاده می‌شوند. اولین سلول به صورت (0, 0) اندیس‌گذاری می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان داده‌شده در بالا را با عرض ستون‌ها و ارتفاع ردیف‌ها برابر 70 پوینت و حاشیه‌های سلول قرمز با عرض 5 پوینت ایجاد می‌کند. مختصات اندیس‌های سلول‌ها را نشان می‌دهد؛ مثال سلول‌ها را خالی می‌گذارد و جدول را به صورت `StandardTables_out.pptx` ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی به جدول موجود**

جداول در مجموعه اشکال یک اسلاید ذخیره می‌شوند. برای یافتن یک جدول، بر اشکال تکرار کنید، سپس از کلاس [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید حاوی جدول را بر حسب اندیس آن دریافت کنید.
3. بر اشیاء [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) تکرار کنید تا زمانی که جدول یافت شد متوقف شوید. اگر اسلاید چند جدول دارد، از [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن سلول هدف را به‌روزرسانی کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌کند. سلول در ستون 0، ردیف 1 را به `New` تنظیم می‌کند و نتیجه را به صورت `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول در آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

برای تغییر اندازه یک ردیف در جدول موجود و درک این‌که چرا ارتفاع واقعی می‌تواند بیشتر از حداقل درخواست‌شده باشد، به بخش [Control Row Height](/slides/fa/nodejs-java/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که فریم متن را دارد**

زمانی که کد عمومی پردازش متن یک [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) را از یک جدول دریافت می‌کند، از متد [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) برای دریافت [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) مالک استفاده کنید. برای فریم متن سلول جدول، [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) مالک را برمی‌گرداند و [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) مقدار `null` می‌دهد، حتی اگر خود جدول یک شکل باشد.

مختصات سلول‌ها از طریق متدهای فقط‑خواندنی [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) در دسترس هستند. همچنین [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) ناوبری فقط‑خواندنی را فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. قبل از استفاده، همیشه مقدار `null` برگشته را بررسی کنید.

برای مثال کامل که مالکان سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکال مرتبط با گره‌های SmartArt، به بخش [Search and Replace Text](/slides/fa/nodejs-java/search-and-replace-text/) مراجعه کنید.

## **تراز متن در جدول**

می‌توانید لنگر عمودی و جهت متن سلول‌های جداگانه جدول را کنترل کنید. مثال این بخش متن را در اولین سلول مرکز می‌گیرد و آن را به میزان 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را بر حسب اندیس آن دریافت کنید.
3. یک شیء [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) را به اسلاید اضافه کنید.
4. از جدول یک شیء [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) دریافت کنید.
5. اولین [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) را دریافت کرده و متن و رنگ آن را تنظیم کنید.
6. لنگر عمودی سلول و جهت متن را با استفاده از [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) و [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جدول 4 × 4 با عرض ستون 120 پوینت و ارتفاع ردیف 100 پوینت ایجاد می‌کند. متن سلول (0, 0) قالب‌بندی می‌شود، مقادیر به سلول‌های باقی‌مانده ردیف اول افزوده می‌شود و نتیجه به صورت `Vertical_Align_Text_out.pptx` ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) برای اعمال قالب‌بندی متن به تمام سلول‌های یک جدول استفاده کنید. نسخه‌های overload این متد، قالب‌بندی بخش، پاراگراف و فریم متن را می‌پذیرند، بنابراین می‌توانید این خصوصیات را بدون تکرار بر روی سلول‌های جداگانه تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را بر حسب اندیس آن دریافت کنید.
3. از اسلاید یک شیء [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) دریافت کنید.
4. اندازه قلم را با استفاده از [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) برای متن تنظیم کنید.
5. تراز پاراگراف و حاشیه راست را با استفاده از [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) تنظیم کنید.
6. جهت متن را با استفاده از [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) تنظیم کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

مثال زیر `table.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. اندازه قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را راست‌تراز می‌کند با حاشیه راست 20 پوینت، و متن را عمودی می‌کند. ارائه قالب‌بندی‌شده به صورت `result.pptx` ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های سبک جدول**

از [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) برای خواندن سبک پیش‌تنظیم‌شده جدول و از [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، مقدار پیش‌تنظیم را چاپ می‌کند و همان پیش‌تنظیم را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قفل کردن نسبت طول به عرض جدول**

نسبت طول به عرض یک جدول، نسبت عرض آن به ارتفاع است. از [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت طول به عرض را فعال می‌سازد، وضعیت به‌روزشده (`true`) را چاپ می‌کند و نتیجه را به صورت `pres-out.pptx` ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم جهت خواندن راست‑به‑چپ (RTL) را برای کل جدول و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) را فراهم می‌کند و پاراگراف‌ها متد [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) دارند. استفاده از هر دو تضمین می‌کند که ترتیب و رندر صحیح RTL داخل سلول‌ها اعمال شود.

**چگونه می‌توانم کاربران را از جابجا کردن یا تغییر اندازه جدول در فایل نهایی منع کنم؟**

از [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) برای غیرفعال‌سازی جابجایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر روی جدول‌ها نیز اعمال می‌شوند.

**آیا قرار دادن تصویر به عنوان پس‌زمینه داخل سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول پرکنش تصویر ([picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/)) تنظیم کنید؛ تصویر بر حسب حالت انتخاب‌شده (کشیدگی یا کاشی) ناحیه سلول را پوشش می‌دهد.