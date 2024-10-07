---
title: إدارة الجدول
type: docs
weight: 10
url: /java/manage-table/
keywords: "جدول، إنشاء جدول، الوصول إلى جدول، نسبة عرض إلى ارتفاع الجدول، عرض تقديمي لPowerPoint، جافا، Aspose.Slides لJava"
description: "إنشاء وإدارة الجداول في عروض PowerPoint التقديمية باستخدام جافا"
---

الجدول في PowerPoint هو وسيلة فعالة لعرض المعلومات وتمثيلها. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) واضحة وسهلة الفهم.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) وواجهة [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) وفئة [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) وواجهة [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) وأنواع أخرى للسماح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. عرّف مصفوفة من `columnWidth`.
4. عرّف مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. تكرر عبر كل [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمين واليسار.
7. دمج الخليتين الأول والثاني من الصف الأول للجدول.
8. الوصول إلى [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
10. احفظ العرض التقديمي المعدل.

هذا الكود بلغة جافا يوضح لك كيفية إنشاء جدول في عرض تقديمي:

```java
// ينشئ مثيلًا من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // دمج الخلايا 1 و 2 من الصف 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // إضافة نص جديد إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("خلايا مدمجة");

    // حفظ العرض التقديمي على القرص
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ترقيم الجدول القياسي**

في جدول قياسي، ترقيم الخلايا بسيط ويبدأ من الصفر. تتم فهرسة الخلية الأولى في جدول كـ 0,0 (عمود 0، صف 0).

على سبيل المثال، يتم ترقيم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود بلغة جافا يوضح لك كيفية تحديد الترقيم للخلايا في جدول:

```java
// ينشئ مثيلًا من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // حفظ العرض التقديمي على القرص
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى جدول موجود**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).

2. احصل على مرجع الشريحة التي تحتوي على الجدول من خلال فهرسها.

3. أنشئ كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) واضبطه على null.

4. تكرر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك في أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم تحديد شكل على أنه جدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table) ولكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال [setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. استخدم كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. احفظ العرض التقديمي المعدل.

هذا الكود بلغة جافا يوضح لك كيفية الوصول إلى جدول موجود والعمل معه:

```java
// ينشئ مثيلًا لفئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تهيئة جدول null
    ITable tbl = null;

    // يتكرر عبر الأشكال ويضع مرجعًا إلى الجدول الموجود
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // تعيين النص لعمود الأول من الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("جديد");
        }
    }
    
    // حفظ العرض التقديمي المعدل على القرص
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **محاذاة النص في الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/).
6. محاذاة النص عموديًا.
7. احفظ العرض التقديمي المعدل.

هذا الكود بلغة جافا يوضح لك كيفية محاذاة النص في جدول:

```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // تعريف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // إضافة شكل الجدول إلى الشريحة
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // الوصول إلى إطار النص
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // إنشاء كائن الفقرة لإطار النص
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // إنشاء كائن Portion للفقرة
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("نص هنا");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // محاذاة النص عموديًا
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // حفظ العرض التقديمي على القرص
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق النص على مستوى الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. احفظ العرض التقديمي المعدل.

هذا الكود بلغة جافا يوضح لك كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // تعيين ارتفاع خط خلايا الجدول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // تعيين محاذاة نص الخلايا و الهامش الأيمن في دعوة واحدة
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // تعيين نوع النص العمودي لخلايا الجدول
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

تسمح لك Aspose.Slides باسترداد خصائص النمط لجدول حتى تتمكن من استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. هذا الكود بلغة جافا يوضح لك كيفية الحصول على خصائص النمط من نمط الجدول المحدد مسبقًا:

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

## **قفل نسبة عرض إلى ارتفاع الجدول**

نسبة عرض إلى ارتفاع الشكل الهندسي هي نسبة أبعاده في أبعاد مختلفة. قدمت Aspose.Slides خاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

هذا الكود بلغة جافا يوضح لك كيفية قفل نسبة العرض إلى الارتفاع للجدول:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("قفل نسبة العرض إلى الارتفاع تم ضبطه: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // عكس

    System.out.println("قفل نسبة العرض إلى الارتفاع تم ضبطه: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```