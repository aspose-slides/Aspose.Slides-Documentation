---
title: إدارة الخلايا
type: docs
weight: 30
url: /java/manage-cells/
keywords: "جدول, خلايا مدمجة, خلايا مقسمة, صورة في خلية الجدول, جافا, Aspose.Slides لجافا"
description: "خلايا الجدول في عروض PowerPoint التقديمية في جافا"
---


## **تحديد خلية جدول مدمجة**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على الجدول من الشريحة الأولى. 
3. التكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عند العثور على خلايا مدمجة.

يوضح كود جافا هذا كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

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
                System.out.println(String.format("الخلايا %d;%d هي جزء من خلية مدمجة مع RowSpan=%d و ColSpan=%d تبدأ من الخلية %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة حدود خلايا الجدول**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. تعريف مصفوفة من الأعمدة بعرض.
4. تعريف مصفوفة من الصفوف بارتفاع.
5. إضافة جدول إلى الشريحة من خلال طريقة [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. التكرار عبر كل خلية لمسح الحدود العلوية والسفلية واليمنى واليسرى.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح كود جافا هذا كيفية إزالة الحدود من خلايا الجدول:

```java
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرض والصفوف بارتفاع
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // إضافة شكل الجدول إلى الشريحة
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
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

    // كتابة PPTX إلى القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ترقيم في خلايا مدمجة**
إذا قمنا بدمج زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، سيكون الجدول الناتج مرقمًا. يتناول كود جافا هذا العملية:

```java
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرض والصفوف بارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل الجدول إلى الشريحة
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

    // دمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ثم نقوم بدمج الخلايا بشكل أكبر عن طريق دمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في وسطه:

```java
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرض والصفوف بارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل الجدول إلى الشريحة
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

    // دمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // دمج الخلايا (1, 1) × (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// كتابة ملف PPTX إلى القرص
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ترقيم في خلية مقسمة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير النظام العددي في خلايا أخرى. 

هذه المرة، نحن نأخذ جدولًا عاديًا (جدولًا بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي يقوم بها Microsoft PowerPoint بترقيم خلايا الجدول وتقوم Aspose.Slides بنفس الشيء.

يوضح كود جافا هذا العملية التي وصفناها:

```java
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرض والصفوف بارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل الجدول إلى الشريحة
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

    // دمج الخلايا (1, 1) × (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1, 2) × (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // تقسيم الخلية (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // كتابة ملف PPTX إلى القرص
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير لون خلفية خلية الجدول**

يوضح كود جافا هذا كيفية تغيير لون خلفية خلية الجدول:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // إنشاء جدول جديد
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // تعيين لون الخلفية لخلية 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إضافة صورة داخل خلية الجدول**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. تعريف مصفوفة من الأعمدة بعرض.
4. تعريف مصفوفة من الصفوف بارتفاع.
5. إضافة جدول إلى الشريحة من خلال طريقة [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. إنشاء كائن `Images` لحفظ ملف الصورة.
7. إضافة الصورة `IImage` إلى كائن `IPPImage`.
8. تعيين `FillFormat` لخلية الجدول إلى `صورة`.
9. إضافة الصورة إلى أول خلية في الجدول.
10. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح كود جافا هذا كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

```java
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide islide = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرض والصفوف بارتفاع
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // إضافة شكل الجدول إلى الشريحة
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // إنشاء كائن IPPImage باستخدام ملف الصورة
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة الصورة إلى أول خلية في الجدول
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // حفظ ملف PPTX إلى القرص
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```