---
title: إدارة جداول العروض التقديمية في JavaScript
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/nodejs-java/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتحرير الجداول في شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---

الجدول في PowerPoint هو طريقة فعّالة لعرض وتقديم المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) واضحة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) والفئة [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) وغيرها من الأنواع لتمكينك من إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. تحديد مصفوفة `columnWidth`.
4. تحديد مصفوفة `rowHeight`.
5. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. المرور على كل [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأوليتين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بـ [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/).
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يعرف الأعمدة بعروضها والصفوف بارتفاعاتها
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // يضيف شكل جدول إلى الشريحة
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضبط تنسيق الحدود لكل خلية
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
    // يدمج الخليتين 1 و 2 في الصف 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // يضيف بعض النص إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // يحفظ العرض التقديمي على القرص
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



## **الترقيم في الجدول القياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. الخلية الأولى في الجدول تُرقم كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، يتم ترقيم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف كما يلي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود JavaScript يوضح لك كيفية تحديد الترقيم للخلايا في جدول:
```javascript
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بعروضها والصفوف بارتفاعاتها
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
    // يحفظ العرض التقديمي على القرص
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الوصول إلى جدول موجود**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).

2. الحصول على مرجع الشريحة التي تحتوي على الجدول عبر فهرستها. 

3. إنشاء كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) وتعيينه إلى null.

4. المرور عبر جميع كائنات [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) حتى يتم العثور على الجدول.

   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table). ولكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر الخاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. استخدام كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. حفظ العرض التقديمي المعدل.

```javascript
// ينشئ فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يهيئ TableEx إلى null
    var tbl = null;
    // يتكرر عبر الأشكال ويحدد مرجعًا للجدول الموجود
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // يحدد النص للعمود الأول من الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // يحفظ العرض التقديمي المعدل على القرص
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **محاذاة النص في الجدول**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) إلى الشريحة.
4. الوصول إلى كائن [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) من الجدول.
5. الوصول إلى [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) داخل [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

```javascript
// ينشئ مثلاً لفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // يحدد الأعمدة بعروضها والصفوف بارتفاعاتها
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // يضيف شكل الجدول إلى الشريحة
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // يصل إلى إطار النص
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // ينشئ كائن الفقرة لإطار النص
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // ينشئ كائن الجزء للفقرة
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // يضبط محاذاة النص عمودياً
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // يحفظ العرض التقديمي على القرص
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) من الشريحة.
4. تحديد [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تحديد [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. تحديد [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض التقديمي المعدل. 

```javascript
// ينشئ مثلاً لفئة Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يحدد ارتفاع خط خلايا الجدول
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // يحدد محاذاة نص خلايا الجدول والهامش الأيمن في نداء واحد
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // يحدد نوع النص العمودي لخلايا الجدول
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


## **الحصول على خصائص نمط الجدول**

يتيح لك Aspose.Slides استرجاع خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// تغيير سمة الإعداد الافتراضي للنمط
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي نسبة أبعاده في الأبعاد المختلفة. توفر Aspose.Slides الخاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) لتتيح لك قفل إعداد نسبة العرض إلى الارتفاع للجداول وغيرها من الأشكال.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// عكس
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يمكنني تفعيل اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفّر الجدول الطريقة [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/) وتتوفر الفقرات على [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). استخدامهما معًا يضمن الترتيب والأنماط الصحيحة للـ RTL داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم أقفال الأشكال لتعطيل التحريك، وتغيير الحجم، والتحديد، وغيرها. هذه الأقفال تنطبق على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تجانب).