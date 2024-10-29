---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/androidjava/manage-cells/
keywords: "جدول، خلايا مدمجة، خلايا مقسمة، صورة في خلية جدول، جافا، Aspose.Slides for Android via Java"
description: "خلايا الجدول في عروض PowerPoint التقديمية في جافا"
---

## **تحديد خلية الجدول المدمجة**
1. قم بإنشاء مثيل من  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. احصل على الجدول من الشريحة الأولى.
3. قم بالتكرار عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. اطبع رسالة عند العثور على الخلايا المدمجة.

يوضح هذا الكود بجافا كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

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
                System.out.println(String.format("Cell %d;%d هو جزء من خلية مدمجة مع RowSpan=%d و ColSpan=%d بدءًا من Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة إطار خلايا الجدول**
1. قم بإنشاء مثيل من  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. قم بتعريف مصفوفة من الأعمدة مع العرض.
4. قم بتعريف مصفوفة من الصفوف مع الارتفاع.
5. أضف جدولًا إلى الشريحة من خلال [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. قم بالتكرار عبر كل خلية لإزالة الحدود العلوية والسفلية واليمينية واليسارية.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بجافا كيفية إزالة الحدود من خلايا الجدول:

```java
// يتجنب توضيح كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
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

    // كتابة ملف PPTX على القرص
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ترقيم في خلايا مدمجة**
إذا قمنا بدمج زوجين من الخلايا (1، 1) x (2، 1) و (1، 2) x (2، 2)، فإن الجدول الناتج سيتم ترقيمه. يوضح هذا الكود بجافا العملية:

```java
// يتجنب توضيح كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
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

    // دمج الخلايا (1، 1) x (2، 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1، 2) x (2، 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ثم نقوم بدمج الخلايا مرة أخرى عن طريق دمج (1، 1) و (1، 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في وسطه:

```java
// يتجنب توضيح كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
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

    // دمج الخلايا (1، 1) x (2، 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1، 2) x (2، 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // دمج الخلايا (1، 1) x (1، 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// كتابة ملف PPTX على القرص
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ترقيم في الخلية المقسومة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير الترقيم أو النظام العددي في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1،1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي يعد بها Microsoft PowerPoint خلايا الجدول وAspose.Slides يفعل نفس الشيء.

يوضح هذا الكود بجافا العملية التي وصفناها:

```java
// يتجنب توضيح كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
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

    // دمج الخلايا (1، 1) x (2، 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // دمج الخلايا (1، 2) x (2، 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // تقسيم الخلية (1، 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // كتابة ملف PPTX على القرص
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير لون خلفية خلية الجدول**

يوضح هذا الكود بجافا كيفية تغيير لون خلفية خلية الجدول:

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

1. قم بإنشاء مثيل من  [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. قم بتعريف مصفوفة من الأعمدة مع العرض.
4. قم بتعريف مصفوفة من الصفوف مع الارتفاع.
5. أضف جدولًا إلى الشريحة من خلال [AddTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. قم بإنشاء كائن `Images` لحفظ ملف الصورة.
7. أضف الصورة `IImage` إلى كائن `IPPImage`.
8. قم بتعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. أضف الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بجافا كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

```java
// يتجنب توضيح كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide islide = pres.getSlides().get_Item(0);

    // تعريف الأعمدة بعرضها والصفوف بارتفاعاتها
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

    // إضافة الصورة إلى الخلية الأولى في الجدول
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // حفظ ملف PPTX على القرص
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```