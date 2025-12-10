---
title: إدارة خلايا الجدول في العروض التقديمية في .NET
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/net/manage-cells/
keywords:
- خلية جدول
- دمج الخلايا
- إزالة الحدود
- تقسيم الخلية
- صورة في الخلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة خلايا الجدول بسهولة في PowerPoint باستخدام Aspose.Slides لـ .NET. إتقان الوصول إلى الخلايا وتعديلها وتنسيقها بسرعة لتحقيق أتمتة سلسة للشرائح."
---

## **Identify a Merged Table Cell**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‏.
2. الحصول على الجدول من الشريحة الأولى.
3. التنقل عبر صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. طباعة رسالة عندما يتم العثور على خلايا مدمجة.

يوضح لك هذا الكود C# كيفية تحديد الخلايا المدمجة في جدول عرض تقديمي:
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
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **Remove Table Cell Borders**

1. إنشاء مثيل من الفئة `Presentation`.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تعريف مصفوفة الأعمدة مع العرض.
4. تعريف مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة `AddTable`.
6. التنقل عبر كل خلية لإزالة الحدود العليا والسفلى واليمين واليسار.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح لك هذا الكود C# كيفية إزالة الحدود من خلايا الجدول:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{
   // الوصول إلى الشريحة الأولى
    Slide sld = (Slide)pres.Slides[0];

    // تعريف الأعمدة بالأعرض والصفوف بالأارتفاعات
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

    // كتابة ملف PPTX إلى القرص
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Numbering in Merged Cells**

إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و(1, 2) × (2, 2)، سيُرقم الجدول الناتج. يُظهر هذا الكود C# العملية:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // تعريف الأعمدة بالعرض والصفوف بالارتفاع
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


ثم ندمج الخلايا أكثر بدمج (1, 1) و(1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في وسطه:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يعرّف الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // يحدد تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) × (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // يدمج الخلايا (1, 2) × (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // يدمج الخلايا (1, 2) × (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // يكتب ملف PPTX إلى القرص
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **Numbering in a Splitted Cell**

في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم أو الأرقام في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، والذي قد يبدو غريبًا. ومع ذلك، هذه هي الطريقة التي يقوم بها Microsoft PowerPoint بترقيم خلايا الجداول ويقوم Aspose.Slides بنفس الشيء.

يوضح هذا الكود C# العملية التي وصفناها:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يعرّف الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) × (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // يدمج الخلايا (1, 2) × (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // يفصل الخلية (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // يكتب ملف PPTX إلى القرص
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Change the Table Cell Background Color**

يوضح لك هذا الكود C# كيفية تغيير لون خلفية خلية في جدول:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // إنشاء جدول جديد
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // تعيين لون الخلفية للخلية 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **Add an Image Inside a Table Cell**

1. إنشاء نسخة من الفئة `Presentation`.
2. الحصول على مرجع الشريحة عبر فهرستها.
3. تعريف مصفوفة الأعمدة مع العرض.
4. تعريف مصفوفة الصفوف مع الارتفاع.
5. إضافة جدول إلى الشريحة عبر طريقة `AddTable`.
6. إنشاء كائن `Bitmap` لحفظ ملف الصورة.
7. إضافة صورة الـ bitmap إلى كائن `IPPImage`.
8. تعيين `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح لك هذا الكود C# كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```c#
// ينشئ كائنًا من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يعرّف الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // يحمل صورة من ملف ويضيفها إلى موارد العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف الصورة إلى الخلية الأولى في الجدول
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // يحفظ ملف PPTX إلى القرص
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

نعم. حدود [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) لها خصائص منفصلة، لذلك يمكن أن تختلف السماكة والنمط لكل جانب. هذا يتبع منطقياً من التحكم في الحدود حسب كل جانب للخلية كما هو موضح في المقال.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). مع التمديد، تتكيف الصورة مع الخلية الجديدة؛ ومع وضع البلاط، يتم إعادة حساب البلاط. يذكر المقال أوضاع عرض الصورة داخل الخلية.

**Can I assign a hyperlink to all the content of a cell?**

يتم تعيين [Hyperlinks](/slides/ar/net/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عملياً، يمكنك تعيين الرابط إلى جزء أو إلى كل النص داخل الخلية.

**Can I set different fonts within a single cell?**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (مقاطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.