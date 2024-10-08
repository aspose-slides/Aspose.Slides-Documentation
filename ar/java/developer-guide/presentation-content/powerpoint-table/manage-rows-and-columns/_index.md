---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /ar/java/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، عرض PowerPoint، Java، Aspose.Slides for Java"
description: "إدارة صفوف وأعمدة الجدول في عروض PowerPoint باستخدام Java"
---

لتمكينك من إدارة صفوف وأعمدة الجدول في عرض PowerPoint، توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) وقم بتعيينه إلى null.
4. قم بالتكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعثور على الجدول المعني.
5. قم بتعيين الصف الأول من الجدول كعنوان له.

يوضح لك هذا الرمز بلغة Java كيفية تعيين الصف الأول من الجدول كعنوان له:

```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تهيئة جدول TableEx إلى null
    ITable tbl = null;

    // التكرار عبر الأشكال وتعيين مرجع للجدول
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // تعيين الصف الأول من الجدول كعنوان له
            tbl.setFirstRow(true);
        }
    }
    
    // حفظ العرض على القرص
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استنساخ صف أو عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. حدد مصفوفة `columnWidth`.
4. حدد مصفوفة `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. استنسخ صف الجدول.
7. استنسخ عمود الجدول.
8. احفظ العرض المعدل.

يوضح لك هذا الرمز بلغة Java كيفية استنساخ صف أو عمود من جدول PowerPoint:

```java
 // ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تحديد الأعمدة بعرضها والصفوف بارتفاعاتها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // إضافة نص إلى خلية الصف 1 العمود 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // إضافة نص إلى خلية الصف 1 العمود 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // استنساخ الصف 1 في نهاية الجدول
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // إضافة نص إلى خلية الصف 2 العمود 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // إضافة نص إلى خلية الصف 2 العمود 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // استنساخ الصف 2 كصف 4 من الجدول
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // استنساخ العمود الأول في النهاية
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // استنساخ العمود الثاني عند الفهرس 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    
    // حفظ العرض على القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة صف أو عمود من الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. حدد مصفوفة `columnWidth`.
4. حدد مصفوفة `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. أزل صف الجدول.
7. أزل عمود الجدول.
8. احفظ العرض المعدل.

يوضح لك هذا الرمز بلغة Java كيفية إزالة صف أو عمود من جدول:

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

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) المعني من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا الصف الأول.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا الصف الأول.
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا الصف الثاني.
7. احفظ العرض المعدل.

يوضح لك هذا الرمز بلغة Java العملية.

```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation();
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // تعيين ارتفاع خط خلايا الصف الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // تعيين محاذاة النص و الهامش الأيمن لخلايا الصف الأول
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // تعيين نوع النص العمودي لخلايا الصف الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // حفظ العرض على القرص
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) المعني من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) لخلايا العمود الأول.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) لخلايا العمود الأول.
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) لخلايا العمود الثاني.
7. احفظ العرض المعدل.

يوضح لك هذا الرمز بلغة Java العملية:

```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation();
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // تعيين ارتفاع خط خلايا العمود الأول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // تعيين محاذاة النص و الهامش الأيمن لخلايا العمود الأول في استدعاء واحد
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // تعيين نوع النص العمودي لخلايا العمود الثاني
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

تسمح لك Aspose.Slides باسترداد خصائص النمط لجدول حتى يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الرمز بلغة Java كيفية الحصول على خصائص النمط من نمط جدولي محدد:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير نمط القالب الافتراضي
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```