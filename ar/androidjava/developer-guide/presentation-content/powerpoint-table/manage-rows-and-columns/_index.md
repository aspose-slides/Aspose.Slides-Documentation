---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /ar/androidjava/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، تقديم باوربوينت، جافا، Aspose.Slides for Android via Java"
description: "إدارة صفوف وأعمدة الجدول في عروض باوربوينت باستخدام جافا"
---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض باوربوينت، يوفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) وقم بتعيينه إلى null.
4. قم بالتكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعثور على الجدول المعني.
5. قم بتعيين الصف الأول للجدول كعنوان له.

يظهر لك هذا الكود في جافا كيفية تعيين الصف الأول للجدول كعنوان له:

```java
// ينشئ مثيل من فئة Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // تصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يهيئ الجدول null
    ITable tbl = null;

    // يتكرر عبر الأشكال ويعين مرجعًا إلى الجدول
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //يحدد الصف الأول للجدول كعنوان له
            tbl.setFirstRow(true);
        }
    }
    
    // يحفظ العرض إلى القرص
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استنساخ صف أو عمود من الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال فهرسها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. استنسخ صف الجدول.
7. استنسخ عمود الجدول.
8. احفظ العرض المعدل.

يظهر لك هذا الكود في جافا كيفية استنساخ صف أو عمود من جدول باوربوينت:

```java
 // ينشئ مثيل من فئة Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // تصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة مع العرض والصفوف مع الارتفاع
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضيف نصًا إلى خلية الصف 1 العمود 1
    table.get_Item(0, 0).getTextFrame().setText("الصف 1 الخلية 1");

    // يضيف نصًا إلى خلية الصف 1 العمود 2
    table.get_Item(1, 0).getTextFrame().setText("الصف 1 الخلية 2");

    // يستنسخ الصف 1 في نهاية الجدول
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // يضيف نصًا إلى خلية الصف 2 العمود 1
    table.get_Item(0, 1).getTextFrame().setText("الصف 2 الخلية 1");

    // يضيف نصًا إلى خلية الصف 2 العمود 2
    table.get_Item(1, 1).getTextFrame().setText("الصف 2 الخلية 2");

    // يستنسخ الصف 2 كصف رابع من الجدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // يستنسخ العمود الأول في النهاية
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // يستنسخ العمود الثاني في فهرس العمود الرابع
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // يحفظ العرض إلى القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة صف أو عمود من الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال فهرسها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. قم بإزالة صف الجدول.
7. قم بإزالة عمود الجدول.
8. احفظ العرض المعدل.

يظهر لك هذا الكود في جافا كيفية إزالة صف أو عمود من جدول:

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

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) المعني من الشريحة.
4. قم بتعيين [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا الصف الأول.
5. قم بتعيين [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا الصف الأول.
6. قم بتعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا الصف الثاني.
7. احفظ العرض المعدل.

هذا الكود في جافا يوضح العملية:

```java
// ينشئ مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // دعنا نفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // يحدد ارتفاع خط خلايا الصف الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // يحدد محاذاة النص و الهامش الأيمن لخلايا الصف الأول
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // يحدد نوع النص العمودي للخلايا الصف الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // يحفظ العرض إلى القرص
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) المعني من الشريحة.
4. قم بتعيين [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا العمود الأول.
5. قم بتعيين [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا العمود الأول.
6. قم بتعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا العمود الثاني.
7. احفظ العرض المعدل.

هذا الكود في جافا يوضح العملية: 

```java
// ينشئ مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // دعنا نفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // يحدد ارتفاع خط خلايا العمود الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // يحدد محاذاة النص و الهامش الأيمن لخلايا العمود الأول في مكالمة واحدة
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // يحدد نوع النص العمودي للخلايا العمود الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

يسمح لك Aspose.Slides باسترداد خصائص النمط لجدول بحيث يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. يظهر لك هذا الكود في جافا كيفية الحصول على خصائص النمط من نمط الجدول المسبق:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير نمط الصورة الافتراضي
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```