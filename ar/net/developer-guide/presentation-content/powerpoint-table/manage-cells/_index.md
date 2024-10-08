---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/net/manage-cells/
keywords:
- جدول
- خلايا مدمجة
- خلايا مفصولة
- صورة في خلية جدول
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "خلايا الجدول في عروض PowerPoint باستخدام C# أو .NET"
---

## **تحديد خلية الجدول المدمجة**

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. احصل على الجدول من الشريحة الأولى. 
3. قم بتكرار صفوف وأعمدة الجدول للعثور على خلايا مدمجة.
4. اطبع رسالة عند العثور على خلايا مدمجة.

يوضح هذا الكود C# كيفية تحديد خلايا الجدول المدمجة في عرض تقديمي:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // افتراض أن Slide#0.Shape#0 هو جدول
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("الخانة {0};{1} هي جزء من خلية مدمجة ب RowSpan={2} و ColSpan={3} تبدأ من الخانة {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **إزالة حدود خلايا الجدول**
1. أنشئ مثيلاً من فئة `Presentation`.
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. قم بتعريف مصفوفة من الأعمدة مع عرض.
4. قم بتعريف مصفوفة من الصفوف مع ارتفاع.
5. أضف جدولاً إلى الشريحة من خلال طريقة `AddTable`.
6. تكرار كل خلية لإزالة الحدود العلوية والسفلية واليمنى واليسرى.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود C# كيفية إزالة الحدود من خلايا الجدول:

```c#
// أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
   // الوصول إلى الشريحة الأولى
    Slide sld = (Slide)pres.Slides[0];

    // تعريف الأعمدة بعرض والصفوف بارتفاعات
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // كتابة ملف PPTX على القرص
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الترقيم في الخلايا المدمجة**
إذا قمنا بدمج زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، فإن الجدول الناتج سيتم ترقيمه. يوضح هذا الكود C# العملية:

```c#
// أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // تعريف الأعمدة بعرض والصفوف بارتفاعات
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل جدول إلى الشريحة
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // دمج الخلايا (1, 1) × (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // دمج الخلايا (1, 2) × (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

ثم نقوم بمزيد من دمج الخلايا من خلال دمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية كبيرة مدمجة في وسطه:

```c#
// أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // تعريف الأعمدة بعرض والصفوف بارتفاعات
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // دمج الخلايا (1, 1) × (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // دمج الخلايا (1, 2) × (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // دمج الخلايا (1, 2) × (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // كتابة ملف PPTX إلى القرص
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **الترقيم في الخلية المفصولة**
في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير الترقيم أو النظام العددي في الخلايا الأخرى. 

هذه المرة، نستخدم جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1, 1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يعتبر غريبًا. ومع ذلك، هذه هي الطريقة التي يقوم بها Microsoft PowerPoint بترقيم خلايا الجدول وAspose.Slides يفعل نفس الشيء. 

يوضح هذا الكود C# العملية التي وصفناها:

```c#
// أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // تعريف الأعمدة بعرض والصفوف بارتفاعات
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // تعيين تنسيق الحدود لكل خلية
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // دمج الخلايا (1, 1) × (2، 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // دمج الخلايا (1, 2) × (2، 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // تقسيم الخلية (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // كتابة ملف PPTX على القرص
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير لون خلفية خلية الجدول**

يوضح هذا الكود C# كيفية تغيير لون خلفية خلية الجدول:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // إنشاء جدول جديد
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // تعيين لون الخلفية لخلية 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **إضافة صورة داخل خلية جدول**

1. أنشئ مثيلاً من فئة `Presentation`.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بتعريف مصفوفة من الأعمدة مع عرض.
4. قم بتعريف مصفوفة من الصفوف مع ارتفاع.
5. أضف جدولاً إلى الشريحة من خلال طريقة `AddTable`. 
6. أنشئ كائن `Bitmap` لاحتواء ملف الصورة.
7. أضف صورة bitmap إلى كائن `IPPImage`.
8. قم بتعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. أضف الصورة إلى أول خلية في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود C# كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:

```c#
// أنشئ مثيلاً من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // تعريف الأعمدة بعرض والصفوف بارتفاعات
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // تحميل صورة من ملف وإضافتها إلى موارد العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // إضافة الصورة إلى أول خلية في الجدول
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // حفظ ملف PPTX على القرص
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```