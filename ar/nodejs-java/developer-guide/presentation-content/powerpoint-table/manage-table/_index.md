---
title: إدارة جداول العروض التقديمية في JavaScript
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/nodejs-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **مقدمة**

الجداول في PowerPoint تنظم المعلومات في صفوف وأعمدة، مما يجعل من السهل قراءة القيم ومقارنتها.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) والفئة [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في العروض التقديمية.

## **إنشاء جدول من الصفر**

إنشاء جدول عن طريق تحديد موقعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج نص.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة باستخدام فهرسها.
3. تحديد مصفوفة عرض الأعمدة بالنقاط.
4. تحديد مصفوفة ارتفاع الصفوف بالنقاط.
5. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) .
6. تكرار عبر كل [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) لتطبيق تنسيق على الحدود العليا والسفلى واليمنى واليسرى.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. الوصول إلى الخلية المدموجة عبر طريقة [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) .
9. ضبط النص في الخلية المدموجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف عند (100, 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة باسم `table.pptx`.

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

## **الترقيم في جدول قياسي**

في جدول قياسي، تكون مؤشرات الخلايا صفرية وتستخدم الترتيب (عمود، صف). تُعطى الخلية الأولى الفهرس (0, 0).

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعروض أعمدة وارتفاعات صفوف قدرها 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. توضح الإحداثيات مؤشرات الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول باسم `StandardTables_out.pptx`.

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

## **الوصول إلى جدول موجود**

تُخزن الجداول في مجموعة الأشكال الخاصة بالشريحة. قم بالتكرار عبر الأشكال لتحديد جدول، ثم استخدم فئة [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) لقراءة أو تحديث خلاياه.

1. قم بتحميل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول باستخدام فهرسها.
3. تكرار عبر كائنات [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) وتوقف عندما يُعثر على جدول. إذا احتوت الشريحة على عدة جداول، استخدم [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `UpdateExistingTable.pptx` ويعثر على أول جدول في الشريحة الأولى. يعين الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة باسم `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، ويجب أن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل و صفين على الأقل.

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

لضبط حجم صف في جدول موجود وفهم لماذا قد يتجاوز ارتفاعه الفعلي الحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/nodejs-java/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تملك إطار نص**

عند استلام كود معالجة النص العامة لكائن [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) من جدول، استخدم طريقة [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) لاسترجاع [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) المالكة. بالنسبة لإطار نص خلية جدول، تُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) المالك وتُعيد [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) القيمة `null`، رغم أن الجدول نفسه شكل.

إحداثيات الخلية متاحة عبر الطريقتين المقروءتين فقط [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) و [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . كما توفر [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) تنقلًا مقروءًا فقط: تُعيد المالك لكنها لا تغير الملكية. يجب دائمًا التحقق من أن الخلية المعادة ليست `null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلية الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/nodejs-java/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في التثبيت العمودي واتجاه النص لخلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويديره بزاوية 270 درجة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة باستخدام فهرسها.
3. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى أول [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) وضبط نصه ولونه.
6. ضبط تثبيت الخلية العمودي واتجاه النص باستخدام [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) و [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدول 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى باقي الخلايا في الصف الأول، ويحفظ النتيجة باسم `Vertical_Align_Text_out.pptx`.

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

## **ضبط تنسيق النص على مستوى الجدول**

استخدم [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعم الإصدارات المتعددة من هذه الطريقة تنسيق الجزء، الفقرة، وإطار النص، بحيث يمكنك ضبط هذه الخصائص دون التكرار عبر الخلايا الفردية.

1. قم بتحميل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة باستخدام فهرسها.
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) من الشريحة.
4. ضبط حجم الخط باستخدام [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. ضبط محاذاة الفقرة والهامش الأيمن باستخدام [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) .
6. ضبط اتجاه النص باستخدام [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل فيها. يضبط حجم الخط إلى 25 نقطة، يمحاذاة الفقرات إلى اليمين مع هامش أيمن 20 نقطة، ويجعل النص عموديًا. يتم حفظ العرض التقديمي المنسق باسم `result.pptx`.

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

## **الحصول على خصائص نمط الجدول**

استخدم [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) لقراءة نمط الجدول المُعد مسبقًا و[setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) لتعيينه. يطبق هذا المثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) على جدول واحد، يطبع قيمة النمط، ويعيّن نفس النمط لجدول ثاني. يُحفظ كلا الجدولين في `table-style.pptx`.

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

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة عرض الجدول إلى ارتفاعه هي نسبة عرضه إلى ارتفاعه. استخدم [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) لقفل هذه النسبة للجدول.

المثال أدناه يفتح `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل فيها. يطبع حالة القفل الحالية، يفعّل قفل نسبة العرض إلى الارتفاع، يطبع الحالة المحدثة (`true`)، ويحفظ النتيجة باسم `pres-out.pptx`.

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

## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفِّر الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-)، وتتوفر الفقرات على [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). قد يؤدي استخدامهما معًا إلى ضمان الترتيب الصحيح RTL والعرض داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) لتعطيل التحريك، تغيير الحجم، التحديد، وغيرها. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمتد أو تبليط).