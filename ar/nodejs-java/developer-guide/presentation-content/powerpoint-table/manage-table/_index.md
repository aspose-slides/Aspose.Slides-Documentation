---
title: إدارة جداول العروض التقديمية باستخدام JavaScript
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
description: "إنشاء وتحرير الجداول في شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول."
---
## **مقدمة**

الجدول في PowerPoint هو وسيلة فعالة لعرض وتصور المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بسيطة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) والفئة [Cell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/) وأنواعًا أخرى لتتيح لك إنشاء الجداول وتحديثها وإدارتها في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. تعريف مصفوفة من `columnWidth`.
4. تعريف مصفوفة من `rowHeight`.
5. إضافة كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. التكرار عبر كل [Cell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمنى واليسرى.
7. دمج الخلايا الأربعة في زاوية الجدول العليا اليسرى (العمودين الأولين في الصفين الأولين) في خلية واحدة. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/).
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ينشئ فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // تعريف الأعمدة بأعرضها والصفوف بارتفاعاتها
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // إضافة شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // تعيين تنسيق الحدود لكل خلية
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
    // دمج مجموعة الخلايا 2×2 في الزاوية العليا اليسرى في خلية واحدة
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // إضافة بعض النص إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // حفظ العرض التقديمي إلى القرص
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الترقيم في الجدول القياسي**

في جدول قياسي، ترقيم الخلايا بسيط ويبدأ من الصفر. الخلية الأولى في الجدول لها الفهرس 0,0 (العمود 0، الصف 0). 

على سبيل المثال، يتم ترقيم خلايا جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يظهر لك هذا الكود JavaScript كيفية تحديد ترقيم الخلايا في جدول:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ينشئ فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بأعرضها والصفوف بارتفاعاتها
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضبط تنسيق الحدود لكل خلية
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
    // يحفظ العرض التقديمي إلى القرص
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الوصول إلى جدول موجود**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول عبر فهرستها. 
3. إنشاء كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) وتعيينه إلى null.
4. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) حتى يتم العثور على الجدول.

   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل كجدول، يمكنك تحويل نوعه إلى كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table). ولكن إذا كانت الشريحة تحتوي على عدة جداول، فإن الأفضل أن تبحث عن الجدول المطلوب عبر خاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. استخدام كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) للعمل مع الجدول. في المثال أدناه، نحدد نص خلية في الجدول.
6. حفظ العرض التقديمي المعدل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ينشئ فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يهيئ TableEx بقيمة null
    var tbl = null;
    // يتجول عبر الأشكال ويحدد مرجعًا للجدول الموجود
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // يضع النص للعمود الأول من الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // يحفظ العرض التقديمي المعدل إلى القرص
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ابحث عن الخلية التي تمتلك إطار نص**

عند تلقي كود معالجة نص عامة كائن [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) من جدول، استخدم طريقة [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) لاسترجاع الخلية المالكة [Cell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/). بالنسبة لإطار النص داخل خلية جدول، تُعيد [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) المالك وتُعيد [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentShape--) القيمة `null`، رغم أن الجدول نفسه يُعتبر شكلاً.

إحداثيات الخلية متاحة عبر طرق القراءة فقط [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) و[Cell.getFirstRowIndex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). كما توفر [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) تنقلًا للقراءة فقط: تُعيد المالك لكنها لا تغير الملكية. احرص دائمًا على التحقق من أن الخلية المرجعة ليست `null` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/nodejs-java/search-and-replace-text/).

## **محاذاة النص في الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. إضافة كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) الخاص بـ [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ينشئ مثيلاً من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بأعرضها والصفوف بارتفاعاتها
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // يضيف شكل الجدول إلى الشريحة
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // يصل إلى إطار النص
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // ينشئ كائن Paragraph لإطار النص
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // ينشئ كائن Portion للفقرة
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط محاذاة النص عموديًا
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // يحفظ العرض التقديمي إلى القرص
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Table) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// ينشئ مثيلاً من فئة Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // فلنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يضبط ارتفاع خط خلايا الجدول
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // يضبط محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // يضبط نوع النص العمودي لخلايا الجدول
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

## **تعيين نمط جدول مسبق**

توفر Aspose.Slides أنماط الجداول المدمجة في PowerPoint كعدد [TableStylePreset](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tablestylepreset/)، بحيث يمكنك تطبيق المظهر نفسه على أي جدول. يوضح لك هذا الكود JavaScript كيفية استبدال النمط الافتراضي للجدول بنمط مسبق:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// تغيير النمط المسبق الافتراضي
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أبعاده المختلفة. توفر Aspose.Slides الخاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) لتتيح لك قفل إعداد نسبة العرض إلى الارتفاع للجداول وغيرها من الأشكال.

يظهر لك هذا الكود JavaScript كيفية قفل نسبة العرض إلى الارتفاع لجدول:

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

## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفّر الجدول الطريقة [setRightToLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/setrighttoleft/) وتملك الفقرات الطريقة [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). باستخدامهما يتم ضمان الترتيب والعرض الصحيح من اليمين إلى اليسار داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم أقفال الشكل لتعطيل التحريك، وتغيير الحجم، والاختيار، إلخ. هذه الأقفال تنطبق على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تجانب).