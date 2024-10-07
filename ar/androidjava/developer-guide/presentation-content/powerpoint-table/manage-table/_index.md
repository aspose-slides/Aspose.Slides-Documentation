---
title: إدارة الجدول
type: docs
weight: 10
url: /androidjava/manage-table/
keywords: "جدول، إنشاء جدول، الوصول إلى جدول، نسبة عرض إلى ارتفاع الجدول، عرض تقديمي PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "إنشاء وإدارة جدول في عروض PowerPoint التقديمية باستخدام Java"
---

الجدول في PowerPoint هو وسيلة فعالة لعرض وتقديم المعلومات. المعلومات الموجودة في شبكة من الخلايا (مرتبة في صفوف وأعمدة) بسيطة وسهلة الفهم.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) ، والواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) ، وفئة [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) ، والواجهة [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) ، وأنواع أخرى تتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. تحديد مصفوفة من `columnWidth` .
4. تحديد مصفوفة من `rowHeight` .
5. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأولتين من الصف الأول للجدول.
8. الوصول إلى [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) .
9. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) .
10. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية إنشاء جدول في عرض تقديمي:

```java
// ينشئ نسخة من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعاتها
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يحدد تنسيق الحدود لكل خلية
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

    // يضيف نصًا إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("الخلايا المدمجة");

    // يحفظ العرض التقديمي على القرص
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الترقيم في الجدول القياسي**

في الجدول القياسي، يكون ترقيم الخلايا بسيطًا وقائمًا على صفر. يتم فهرسة الخلية الأولى في الجدول كـ 0,0 (العمود 0، الصف 0).

على سبيل المثال، يتم ترقيم الخلايا في جدول به 4 أعمدة و4 صفوف على النحو التالي:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يعرض هذا الكود Java كيفية تحديد الترقيم للخلايا في الجدول:

```java
// ينشئ نسخة من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعاتها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يحدد تنسيق الحدود لكل خلية
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

    // يحفظ العرض التقديمي على القرص
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى جدول موجود**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .

2. الحصول على مرجع الشريحة التي تحتوي على الجدول من خلال فهرسها.

3. إنشاء كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) وتعيينه إلى null.

4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشتبه في أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتوي عليها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) . لكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) .

5. استخدم كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية الوصول إلى والعمل مع جدول موجود:

```java
// ينشئ نسخة من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يهيء جدول TableEx إلى null
    ITable tbl = null;

    // يتكرر عبر الأشكال ويحدد مرجعًا للجدول الموجود
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // يحدد النص للعمود الأول من الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("جديد");
        }
    }
    
    // يحفظ العرض التقديمي المعدل على القرص
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **محاذاة النص في الجدول**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) .
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية محاذاة النص في جدول:

```java
// ينشئ نسخة من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحدد الأعمدة بعرضها والصفوف بارتفاعاتها
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // يضيف شكل الجدول إلى الشريحة
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // يصل إلى إطار النص
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // ينشئ كائن Paragraph لإطار النص
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // ينشئ كائن Portion للفقرة
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("نص هنا");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // يحاذي النص عموديًا
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // يحفظ العرض التقديمي على القرص
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```java
// ينشئ نسخة من فئة Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // يحدد ارتفاع خط خلايا الجدول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // يحدد محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // يحدد نوع النص العمودي في خلايا الجدول
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرجاع خصائص النمط لجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يعرض هذا الكود Java كيفية الحصول على خصائص النمط من نمط جدول مُعد مسبقًا:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير نمط الإعداد الافتراضي
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **قفل نسبة أبعاد الجدول**

نسبة الأبعاد لشكل هندسي هي نسبة أحجامه في أبعاد مختلفة. توفر Aspose.Slides خاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) للسماح لك بقفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى.

يعرض هذا الكود Java كيفية قفل نسبة الأبعاد لجدول:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("قفل نسبة الأبعاد مضبوط: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // عكس

    System.out.println("قفل نسبة الأبعاد مضبوط: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```