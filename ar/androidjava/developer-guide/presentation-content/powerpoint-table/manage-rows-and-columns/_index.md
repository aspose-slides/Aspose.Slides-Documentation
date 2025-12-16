---
title: إدارة الصفوف والأعمدة في جداول PowerPoint على Android
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/androidjava/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ الصف
- استنساخ العمود
- نسخ الصف
- نسخ العمود
- إزالة الصف
- إزالة العمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجدول في PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java وتسريع تحرير العروض التقديمية وتحديث البيانات."
---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض تقديمي ببرنامج PowerPoint، تقدم Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كرأس للجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي.  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) وتعيينه إلى null.  
4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعثور على الجدول المناسب.  
5. تعيين الصف الأول من الجدول كرأس له.  

يعرض لك هذا الكود Java كيفية تعيين الصف الأول في الجدول كرأس له:
```java
// يقوم بإنشاء كائن من فئة Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تهيئة TableEx إلى null
    ITable tbl = null;

    // تكرار عبر الأشكال وتعيين مرجع للجدول
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sets ت تعيين الصف الأول للجدول كرأسه
            tbl.setFirstRow(true);
        }
    }
    
    // حفظ العرض التقديمي إلى القرص
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **استنساخ صف أو عمود في الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. تعريف مصفوفة لـ `columnWidth`.  
4. تعريف مصفوفة لـ `rowHeight`.  
5. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. استنساخ صف الجدول.  
7. استنساخ عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يعرض لك هذا الكود Java كيفية استنساخ صف أو عمود من جدول PowerPoint:
```java
 // يقوم بإنشاء كائن من فئة Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يعرّف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضيف بعض النص إلى الصف 1 الخلية 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // يضيف بعض النص إلى الصف 1 الخلية 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // ينسخ الصف 1 في نهاية الجدول
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // يضيف بعض النص إلى الصف 2 الخلية 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // يضيف بعض النص إلى الصف 2 الخلية 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // ينسخ الصف 2 كصف رابع في الجدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // ينسخ العمود الأول في النهاية
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // ينسخ العمود الثاني في الفهرس الرابع للعمود
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // يحفظ العرض التقديمي إلى القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة صف أو عمود من الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. تعريف مصفوفة لـ `columnWidth`.  
4. تعريف مصفوفة لـ `rowHeight`.  
5. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة عبر الطريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. إزالة صف الجدول.  
7. إزالة عمود الجدول.  
8. حفظ العرض التقديمي المعدل.  

يعرض لك هذا الكود Java كيفية إزالة صف أو عمود من جدول:
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


## **تعيين تنسيق النص على مستوى صف الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) المناسب من الشريحة.  
4. تعيين خلايا الصف الأول باستخدام [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. تعيين خلايا الصف الأول باستخدام [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. تعيين خلايا الصف الثاني باستخدام [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. حفظ العرض التقديمي المعدل.  

يوضح هذا الكود Java العملية.
```java
// ينشئ مثالا من فئة Presentation
Presentation pres = new Presentation();
try {
    // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // يحدد ارتفاع الخط لخلايا الصف الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // يحدد محاذاة النص والهوامش اليمنى لخلايا الصف الأول
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // يحدد نوع النص العمودي لخلايا الصف الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // يحفظ العرض التقديمي إلى القرص
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل العرض التقديمي،  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) المناسب من الشريحة.  
4. تعيين خلايا العمود الأول باستخدام [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. تعيين خلايا العمود الأول باستخدام [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. تعيين خلايا العمود الثاني باستخدام [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. حفظ العرض التقديمي المعدل.  

يوضح هذا الكود Java العملية:
```java
// ينشئ مثالا من فئة Presentation
Presentation pres = new Presentation();
try {
    // نفترض أن الشكل الأول في الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // يضبط ارتفاع الخط لخلايا العمود الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // يضبط محاذاة النص والهوامش اليمنى لخلايا العمود الأول في استدعاء واحد
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

تتيح لك Aspose.Slides استرجاع خصائص النمط لجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود Java كيفية الحصول على خصائص النمط من نمط جدول مسبق التعريف:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير سمة النمط الافتراضية
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**  

نعم. يرث الجدول سمة الشريحة/التخطيط/القالب الرئيسي، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**  

لا، جداول Aspose.Slides لا تحتوي على فرز أو تصفيات مدمجة. قم بفرز بياناتك في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (ممتدة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**  

نعم. فعّل الأعمدة المخططة، ثم تجاوز خلايا معينة بالتنسيق المحلي؛ تنسيق الخلية له أولوية أعلى من نمط الجدول.