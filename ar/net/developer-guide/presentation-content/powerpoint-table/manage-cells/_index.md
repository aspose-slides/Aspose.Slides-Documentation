---
title: إدارة الخلايا
type: docs
weight: 30
url: /ar/net/manage-cells/
keywords:
- جدول
- خلايا مدمجة
- خلايا مقسمة
- صورة في خلية جدول
- C#
- Csharp
- Aspose.Slides for .NET
description: "خلايا الجداول في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تحديد خلية جدول مدمجة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على الجدول من الشريحة الأولى.
3. تصفح صفوف وأعمدة الجدول للعثور على الخلايا المدمجة.
4. اطبع رسالة عند العثور على خلايا مدمجة.

يعرض لك هذا الكود بلغة C# كيفية تحديد الخلايا المدمجة في جدول داخل عرض تقديمي:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // بافتراض أن Slide#0.Shape#0 هو جدول
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


## **إزالة حدود خلايا الجدول**

1. إنشاء مثيل من فئة `Presentation`.
2. احصل على مرجع الشريحة عبر مؤشرها.
3. حدد مصفوفة الأعمدة مع العرض.
4. حدد مصفوفة الصفوف مع الارتفاع.
5. أضف جدولًا إلى الشريحة باستخدام طريقة `AddTable`.
6. تصفح كل خلية لإزالة الحدود العلوية والسفلية واليمين واليسار.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود بلغة C# كيفية إزالة الحدود من خلايا الجدول:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
   // الوصول إلى الشريحة الأولى
    Slide sld = (Slide)pres.Slides[0];

    // يحدد الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // يحفظ ملف PPTX إلى القرص
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الترقيم في الخلايا المدمجة**

إذا دمجنا زوجين من الخلايا (1, 1) × (2, 1) و (1, 2) × (2, 2)، سيتم ترقيم الجدول الناتج. يعرض هذا الكود بلغة C# العملية:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // يحدد الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // يضيف شكل جدول إلى الشريحة
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // يضبط تنسيق الحدود لكل خلية
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

    // يدمج الخلايا (1, 1) × (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // يدمج الخلايا (1, 2) × (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


ثم نقوم بدمج الخلايا أكثر بدمج (1, 1) و (1, 2). النتيجة هي جدول يحتوي على خلية مدمجة كبيرة في مركزه:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحدد الأعمدة بالعرض والصفوف بالارتفاع
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

    // يدمج الخلايا (1, 1) × (1, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // يكتب ملف PPTX إلى القرص
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **الترقيم في الخلية المقسمة**

في الأمثلة السابقة، عندما تم دمج خلايا الجدول، لم يتغير نظام الترقيم في الخلايا الأخرى.

هذه المرة، نأخذ جدولًا عاديًا (جدول بدون خلايا مدمجة) ثم نحاول تقسيم الخلية (1,1) للحصول على جدول خاص. قد ترغب في الانتباه إلى ترقيم هذا الجدول، الذي قد يبدو غريبًا. ومع ذلك، هذه هي الطريقة التي يرقم بها Microsoft PowerPoint خلايا الجدول ويقوم Aspose.Slides بنفس الشيء.

يعرض هذا الكود بلغة C# العملية التي وصفناها:
```c#
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحدد الأعمدة بالعرض والصفوف بالارتفاع
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

    // يقسم الخلية (1, 1)
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // يكتب ملف PPTX إلى القرص
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **تغيير لون خلفية خلية الجدول**

يعرض لك هذا الكود بلغة C# كيفية تغيير لون خلفية خلية الجدول:
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


## **إضافة صورة داخل خلية الجدول**

1. إنشاء مثيل من فئة `Presentation`.
2. احصل على مرجع الشريحة عبر فهرستها.
3. حدد مصفوفة الأعمدة بالعرض.
4. حدد مصفوفة الصفوف بالارتفاع.
5. أضف جدولًا إلى الشريحة باستخدام طريقة `AddTable`.
6. إنشاء كائن `Bitmap` لاحتواء ملف الصورة.
7. إضافة صورة الـ`Bitmap` إلى كائن `IPPImage`.
8. ضبط `FillFormat` لخلية الجدول إلى `Picture`.
9. إضافة الصورة إلى الخلية الأولى في الجدول.
10. احفظ العرض التقديمي المعدل كملف PPTX

يعرض لك هذا الكود بلغة C# كيفية وضع صورة داخل خلية جدول عند إنشاء جدول:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحدد الأعمدة بالعرض والصفوف بالارتفاع
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // يحمل صورة من ملف ويضيفها إلى موارد العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف الصورة إلى أول خلية في الجدول
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // يحفظ ملف PPTX إلى القرص
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. الحدود [العليا](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[السفلى](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[اليسرى](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[اليمنى](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) لها خصائص منفصلة، لذا يمكن أن تختلف سماكة كل جانب ونمطه. هذا يتبع منطقياً من التحكم بالحدود لكل جانب كما هو موضح في المقال.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

يعتمد السلوك على [وضع التعبئة](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (تمدد/بلاط). عند التمدد، تتكيف الصورة مع الخلية الجديدة؛ أما عند البلاط، فإعادة حساب البلاط. يذكر المقال وضعيات عرض الصورة داخل الخلية.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى الخلية؟**

يتم ضبط [الارتباطات التشعبية](/slides/ar/net/manage-hyperlinks/) على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل كاملًا. عمليًا، يمكنك تعيين الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [الأجزاء](https://reference.aspose.com/slides/net/aspose.slides/portion/) (المقاطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم واللون.