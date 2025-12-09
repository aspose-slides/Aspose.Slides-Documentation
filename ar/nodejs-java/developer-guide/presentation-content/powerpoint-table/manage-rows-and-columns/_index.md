---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /ar/nodejs-java/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، عرض PowerPoint، Java، Aspose.Slides لـ Node.js عبر Java"
description: "إدارة صفوف وأعمدة الجدول في عروض PowerPoint باستخدام JavaScript"
---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض PowerPoint، توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) والفئة [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) والعديد من الأنواع الأخرى.

## **Set First Row as Header**
## **تعيين الصف الأول كعنوان**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض.
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) وتعيينه إلى null.
4. تجول عبر جميع كائنات [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للعثور على الجدول المناسب.
5. تعيين الصف الأول في الجدول كعنوان له. 

يعرض هذا الكود JavaScript كيفية تعيين الصف الأول في الجدول كعنوان له:
```javascript
// إنشاء كائن من الفئة Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // تهيئة TableEx بـ null
    var tbl = null;
    // التنقل عبر الأشكال وتعيين مرجع للجدول
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // تعيين الصف الأول من الجدول كعنوان
            tbl.setFirstRow(true);
        }
    }
    // حفظ العرض إلى القرص
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Clone Table's Row or Column**
## **نسخ صف أو عمود في الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض،
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تعريف مصفوفة `columnWidth`.
4. تعريف مصفوفة `rowHeight`.
5. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. نسخ صف الجدول.
7. نسخ عمود الجدول.
8. حفظ العرض المعدل.

يعرض هذا الكود JavaScript كيفية نسخ صف أو عمود في جدول PowerPoint:
```javascript
// يقوم بإنشاء كائن من الفئة Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // يصل إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يعرف الأعمدة بعرضها والصفوف بارتفاعها
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // يضيف شكل جدول إلى الشريحة
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // يضيف نصًا إلى الصف 1 الخلية 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // يضيف نصًا إلى الصف 1 الخلية 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // ينسخ الصف 1 في نهاية الجدول
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // يضيف نصًا إلى الصف 2 الخلية 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // يضيف نصًا إلى الصف 2 الخلية 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // ينسخ الصف 2 كصف رابع في الجدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // ينسخ العمود الأول في النهاية
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // ينسخ العمود الثاني في الفهرس الرابع للعمود
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // يحفظ العرض على القرص
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Remove Row or Column from Table**
## **إزالة صف أو عمود من الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض،
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تعريف مصفوفة `columnWidth`.
4. تعريف مصفوفة `rowHeight`.
5. إضافة كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
6. إزالة صف الجدول.
7. إزالة عمود الجدول.
8. حفظ العرض المعدل. 

يعرض هذا الكود JavaScript كيفية إزالة صف أو عمود من الجدول:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Set Text Formatting on Table Row Level**
## **تعيين تنسيق النص على مستوى صف الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض،
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) المناسب من الشريحة.
4. تعيين ارتفاع خط الخلايا في الصف الأول باستخدام [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. تعيين محاذاة الخلايا في الصف الأول باستخدام [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. تعيين نوع النص العمودي للخلايا في الصف الثاني باستخدام [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض المعدل.

يوضح هذا الكود JavaScript العملية.
```javascript
// ينشئ مثيلًا من الفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يضبط ارتفاع خط خلايا الصف الأول
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // يضبط محاذاة نص خلايا الصف الأول والهامش الأيمن
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // يضبط نوع النص العمودي لخلايا الصف الثاني
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // يحفظ العرض على القرص
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Set Text Formatting on Table Column Level**
## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتحميل العرض،
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) المناسب من الشريحة.
4. تعيين ارتفاع خط الخلايا في العمود الأول باستخدام [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. تعيين محاذاة الخلايا في العمود الأول باستخدام [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) و[setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. تعيين نوع النص العمودي للخلايا في العمود الثاني باستخدام [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. حفظ العرض المعدل. 

يوضح هذا الكود JavaScript العملية:
```javascript
// ينشئ مثيلًا من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // لنفرض أن الشكل الأول في الشريحة الأولى هو جدول
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // يضبط ارتفاع خط خلايا العمود الأول
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // يضبط محاذاة نص خلايا العمود الأول والهامش الأيمن في استدعاء واحد
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // يضبط نوع النص العمودي لخلايا العمود الثاني
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Get Table Style Properties**
## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدامها لجدول آخر أو في مكان آخر. يعرض هذا الكود JavaScript كيفية الحصول على خصائص النمط من نمط جدول مسبق:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// تغيير نمط الإعداد المسبق الافتراضي
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**
## **الأسئلة المتكررة**

**Can I apply PowerPoint themes/styles to a table that’s already created?**  
**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.  
نعم. يورث الجدول سمة الشريحة/التخطيط/الرئيسية، ويمكنك أيضًا تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**Can I sort table rows like in Excel?**  
**هل يمكنني فرز صفوف الجدول كما في Excel؟**

No, Aspose.Slides tables don’t have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.  
لا، لا تحتوي جداول Aspose.Slides على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بهذا الترتيب.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**  
**هل يمكنني الحصول على أعمدة متناوبة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.  
نعم. فعّل الأعمدة المتناوبة، ثم تجاوز خلايا محددة بالتنسيق المحلي؛ يتفوق تنسيق الخلية على نمط الجدول.