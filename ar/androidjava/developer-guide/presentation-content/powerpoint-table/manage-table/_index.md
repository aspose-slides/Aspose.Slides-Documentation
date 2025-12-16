---
title: إدارة جداول العروض التقديمية على Android
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/androidjava/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ Android. اكتشف أمثلة كود Java بسيطة لتسريع سير عمل الجداول الخاصة بك."
---

الجدول في PowerPoint هو طريقة فعّالة لعرض وتوصيل المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) تكون واضحة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) ، الواجهة [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) ، الفئة [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) ، الواجهة [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) ، وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تحديد مصفوفة `columnWidth`.
4. تحديد مصفوفة `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) لتطبيق تنسيق على الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأوليين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) .
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) .
10. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Java كيفية إنشاء جدول في عرض تقديمي:
```java
// ينشئ كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
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
    // يدمج الخلايا 1 و 2 من الصف 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // يضيف بعض النص إلى الخلية المدمجة
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // يحفظ العرض التقديمي إلى القرص
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الترقيم في جدول قياسي**

في جدول قياسي، ترقيم الخلايا بسيط ويبدأ من الصفر. الخلية الأولى في جدول لها الفهرس 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

يظهر لك هذا الكود Java كيفية تحديد الترقيم للخلايا في جدول:
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تحديد الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تحديد تنسيق الحدود لكل خلية
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

    // حفظ العرض التقديمي إلى القرص
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الوصول إلى جدول موجود**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع للشريحة التي تحتوي على الجدول عبر فهرستها. 
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) وتعيينه إلى null.
4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تعتقد أن الشريحة التي تعمل عليها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل على أنه جدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table). ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر خاصية [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. استخدام كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Java كيفية الوصول إلى جدول موجود والعمل معه:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تهيئة TableEx بـ null
    ITable tbl = null;

    // يتنقل عبر الأشكال ويحدد مرجعًا للجدول الموجود
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // يحدد النص للعمود الأول في الصف الثاني
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **محاذاة النص في جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) .
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Java كيفية محاذاة النص في جدول:
```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
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
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // يضبط محاذاة النص عموديًا
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // يحفظ العرض التقديمي إلى القرص
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) من الشريحة.
4. تعيين [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) للنص.
5. تعيين [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) و [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. تعيين [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود Java كيفية تطبيق خيارات التنسيق المفضلة على النص في جدول:
```java
// ينشئ مثيلًا من فئة Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // يضبط ارتفاع خط خلايا الجدول
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // يضبط محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // يضبط النوع العمودي لنص خلايا الجدول
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرجاع خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود Java كيفية الحصول على خصائص النمط من نمط جدول مسبق:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // تغيير السمة الافتراضية لنمط الإعداد المسبق
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **قفل نسبة الأبعاد للجدول**

نسبة الأبعاد لشكل هندسي هي نسبة أحجامه في الأبعاد المختلفة. قدمت Aspose.Slides الخاصية [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) لتتيح لك قفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى.

يظهر لك هذا الكود Java كيفية قفل نسبة الأبعاد لجدول:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // عكس

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يعرض الجدول طريقة [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) ، والفقرات لديها [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). يضمن استخدام الطريقتين الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/androidjava/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، الاختيار، إلخ. هذه الأقفال تنطبق على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمتد أو تجانس).