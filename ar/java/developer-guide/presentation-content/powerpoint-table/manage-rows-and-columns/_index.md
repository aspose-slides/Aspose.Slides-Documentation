---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام Java
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/java/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس الجدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجدول في PowerPoint باستخدام Aspose.Slides للـ Java وتسريع تحرير العرض التقديمي وتحديث البيانات."
---

لتمكينك من إدارة صفوف وأعمدة جدول في عرض تقديمي من PowerPoint، توفّر Aspose.Slides فئة [جدول](https://reference.aspose.com/slides/java/com.aspose.slides/table/)، الواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) والعديد من الأنواع الأخرى. 

## **تعيين الصف الأول كعنوان**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وحمّل العرض. 
2. احصل على مرجع الشريحة عبر فهرسها. 
3. أنشئ كائنًا من نوع [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) وضعه على null. 
4. استعرض جميع كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعثور على الجدول المناسب. 
5. عيّن الصف الأول للجدول كعنوان له. 

يعرض هذا الكود بلغة Java كيفية تعيين الصف الأول للجدول كعنوان:
```java
// ينشئ مثيلًا لفئة Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يُهيئ TableEx بقيمة null
    ITable tbl = null;

    // يتجول عبر الأشكال ويعين مرجعًا للجدول
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //يضبط الصف الأول للجدول كعنوان
            tbl.setFirstRow(true);
        }
    }
    
    // يحفظ العرض التقديمي على القرص
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **استنساخ صف أو عمود في الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وحمّل العرض، 
2. احصل على مرجع الشريحة عبر فهرسها. 
3. عرّف مصفوفة `columnWidth`. 
4. عرّف مصفوفة `rowHeight`. 
5. أضف كائنًا من نوع [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. استنسخ صف الجدول. 
7. استنسخ عمود الجدول. 
8. احفظ العرض المعدّل.

يعرض هذا الكود بلغة Java كيفية استنساخ صف أو عمود في جدول PowerPoint:
```java
 // ينشئ مثيلًا لفئة Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضيف بعض النص إلى الصف 1 الخلية 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // يضيف بعض النص إلى الصف 1 الخلية 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // ينسخ الصف 1 إلى نهاية الجدول
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // يضيف بعض النص إلى الصف 2 الخلية 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // يضيف بعض النص إلى الصف 2 الخلية 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // ينسخ الصف 2 كصف رابع في الجدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // ينسخ العمود الأول إلى النهاية
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // ينسخ العمود الثاني في الفهرس الرابع
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // يحفظ العرض التقديمي على القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة صف أو عمود من الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وحمّل العرض، 
2. احصل على مرجع الشريحة عبر فهرسها. 
3. عرّف مصفوفة `columnWidth`. 
4. عرّف مصفوفة `rowHeight`. 
5. أضف كائنًا من نوع [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. أزل صف الجدول. 
7. أزل عمود الجدول. 
8. احفظ العرض المعدّل. 

يعرض هذا الكود بلغة Java كيفية إزالة صف أو عمود من جدول:
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


## **تعيين تنسيق النص على مستوى صفوف الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وحمّل العرض، 
2. احصل على مرجع الشريحة عبر فهرسها. 
3. اطلع على كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) المناسب من الشريحة. 
4. عيّن للخللايا في الصف الأول الخاص بـ [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. عيّن للخللايا في الصف الأول الخاص بـ [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. عيّن للخللايا في الصف الثاني الخاص بـ [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. احفظ العرض المعدّل.

يوضح هذا الكود بلغة Java العملية.
```java
// ينشئ مثيلًا لفئة Presentation
Presentation pres = new Presentation();
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // يضبط ارتفاع خط خلايا الصف الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // يضبط محاذاة نص خلايا الصف الأول والهامش الأيمن
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // يضبط نوع النص العمودي لخلايا الصف الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

    // يحفظ العرض التقديمي على القرص
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تنسيق النص على مستوى أعمدة الجدول**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وحمّل العرض، 
2. احصل على مرجع الشريحة عبر فهرسها. 
3. اطلع على كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) المناسب من الشريحة. 
4. عيّن للخللايا في العمود الأول الخاص بـ [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. عيّن للخللايا في العمود الأول الخاص بـ [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. عيّن للخللايا في العمود الثاني الخاص بـ [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. احفظ العرض المعدّل. 

يوضح هذا الكود بلغة Java العملية: 
```java
// ينشئ مثيلًا لفئة Presentation
Presentation pres = new Presentation();
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // يضبط ارتفاع خط خلايا العمود الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // يضبط محاذاة النص للخلية في العمود الأول والهامش الأيمن في استدعاء واحد
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // يضبط نوع النص العمودي لخلايا العمود الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود بلغة Java كيفية الحصول على خصائص النمط من نمط جدول مسبق:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير نمط السمة الافتراضي المحدد
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/القالب الأساسي، ولا يزال بإمكانك تجاوز ملء الخلايا، والحدود، وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، لا تدعم جداول Aspose.Slides فرزًا أو تصفية مدمجة. قم بفرز البيانات في الذاكرة أولًا، ثم أعد ملء صفوف الجدول بالترتيب المطلوب.

**هل يمكنني الحصول على أعمدة مخططة (متناوبة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز تنسيق الخلايا المحددة بالتنسيق المحلي؛ حيث يتفوّق تنسيق الخلية على نمط الجدول.