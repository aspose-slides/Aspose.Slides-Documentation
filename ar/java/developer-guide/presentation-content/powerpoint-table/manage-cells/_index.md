---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام Java
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/java/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة حد
- تقسيم خلية
- صورة في خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بإدارة خلايا الجدول في PowerPoint بسهولة باستخدام Aspose.Slides للغة Java. احكم الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتحقيق أتمتة سلسة للشرائح."
---

## **تحديد خلية جدول مدمجة**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على الجدول من الشريحة الأولى.
3. تكرار الصفوف والأعمدة في الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عند العثور على خلايا مدمجة.

يظهر لك هذا الكود بلغة Java كيفية تحديد الخلايا المدمجة في جدول داخل عرض تقديمي:
```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // نفترض أن Slide#0.Shape#0 هو جدول
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة حدود خلية الجدول**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. تحديد مصفوفة الأعمدة مع العرض.
4. تحديد مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. التكرار عبر كل خلية لإزالة الحدود العليا والسفلى واليمين واليسار.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود بلغة Java كيفية إزالة الحدود من خلايا الجدول:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // يعرف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // يحفظ ملف PPTX على القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الترقيم في الخلايا المدمجة**
إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، سيتم ترقيم الجدول الناتج. يوضح هذا الكود بلغة Java العملية:
```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يعرف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // يدمج الخلايا (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


بعد ذلك نقوم بدمج الخلايا أكثر بدمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في مركزه:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // يدمج الخلايا (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // يدمج الخلايا (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
	//يحفظ ملف PPTX على القرص
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الترقيم في خلية مقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في إيلاء اهتمام للترقيم في هذا الجدول، الذي قد يبدو غريبًا. ومع ذلك، هذه هي الطريقة التي يقوم بها Microsoft PowerPoint بترقيم خلايا الجداول، وتقوم Aspose.Slides بالأمر نفسه.

يظهر لك هذا الكود بلغة Java العملية التي وصفناها:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بأعرضها والصفوف بأارتفاعها
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // يدمج الخلايا (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // يقسم الخلية (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // يحفظ ملف PPTX على القرص
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير لون خلفية خلية الجدول**
يعرض لك هذا الكود بلغة Java كيفية تغيير لون خلفية خلية الجدول:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // إنشاء جدول جديد
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // تعيين لون الخلفية للخلية 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **إضافة صورة داخل خلية جدول**
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. تحديد مصفوفة الأعمدة مع العرض.
4. تحديد مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. إنشاء كائن `Images` لاحتواء ملف الصورة.
7. إضافة صورة `IImage` إلى كائن `IPPImage`.
8. ضبط `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. حفظ العرض التقديمي المعدل كملف PPTX

يعرض لك هذا الكود بلغة Java كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```java
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide islide = pres.getSlides().get_Item(0);

    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // إنشاء كائن IPPImage باستخدام ملف الصورة
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف الصورة إلى أول خلية في الجدول
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحفظ ملف PPTX على القرص
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**
**هل يمكنني ضبط سماكات خطوط وأنماط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. حدود الـ [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) لها خصائص منفصلة، لذلك يمكن أن تختلف سماكة ونمط كل جانب. هذا منطقي بناءً على التحكم في حدود كل جانب للخلية كما هو موضح في المقال.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (تمديد/تبليط). عند التمديد، تتكيف الصورة مع الخلية الجديدة؛ عند التبليط، تُعاد حساب البلاط. يذكر المقال أوضاع عرض الصورة داخل الخلية.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى الخلية؟**

يتم تعيين [Hyperlinks](/slides/ar/java/manage-hyperlinks/) على مستوى النص (القطعة) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تقوم بتعيين الرابط إلى قطعة أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (تشغيلات) تنسيقًا مستقلاً — عائلة الخط، النمط، الحجم، واللون.