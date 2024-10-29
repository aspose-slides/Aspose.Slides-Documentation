---
title: إدارة الجدول
type: docs
weight: 10
url: /ar/net/manage-table/
keywords: "جدول، إنشاء جدول، الوصول إلى جدول، نسبة عرض إلى ارتفاع الجدول، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "إنشاء وإدارة الجدول في عروض باوربوينت باستخدام C# أو .NET"
---

الجدول في باوربوينت هو وسيلة فعالة لعرض وتقديم المعلومات. المعلومات في شبكة من الخلايا (مرتبة في صفوف وأعمدة) واضحة وسهلة الفهم.

تقدم Aspose.Slides فئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) ، واجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ، فئة [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) ، واجهة [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) ، وأنواع أخرى للسماح لك بإنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. تكرار من خلال كل [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمينية واليسارية.
7. دمج أول خليةين من الصف الأول للجدول.
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) لـ [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/).
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
10. حفظ العرض المعدل.

هذا الكود C# يوضح لك كيفية إنشاء جدول في عرض تقديمي:

```c#
// أنشئ مثيلًا من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// تحديد الأعمدة بعرضها والصفوف بارتفاعها
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// إضافة شكل جدول إلى الشريحة
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// تعيين تنسيق الحدود لكل خلية
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// دمج الخلايا 1 و 2 من الصف 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// إضافة نص جديد إلى الخلية المدمجة
tbl.Rows[0][0].TextFrame.Text = "الخلايا المدمجة";

// حفظ العرض إلى القرص
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **ترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. يتم فهرسة أول خلية في الجدول على أنها 0,0 (العمود 0، الصف 0).

على سبيل المثال، يتم إقران الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود C# يوضح لك كيفية تحديد الترقيم للخلايا في جدول:

```c#
// أنشئ مثيلًا من فئة Presentation تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // تحديد الأعمدة بعرضها والصفوف بارتفاعها
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

    // حفظ العرض إلى القرص
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى جدول موجود**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع إلى الشريحة التي تحتوي على الجدول من خلال مؤشرها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) وعيّن قيمته إلى null.
4. تكرار من خلال جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك في أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة التحقق من جميع الأشكال التي تحتوي عليها. عندما يتم التعرف على شكل على أنه جدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/net/aspose.slides/table/). ولكن إذا كانت الشريحة التي تتعامل معها تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه من خلال [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. استخدم كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض المعدل.

هذا الكود C# يوضح لك كيفية الوصول إلى والعمل مع جدول موجود:

```c#
// أنشئ مثيلًا من فئة Presentation تمثل ملف PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // تهيئة TableEx إلى null
    ITable tbl = null;

    // تكرار من خلال الأشكال وتعيين مرجع إلى الجدول الموجود
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // تعيين النص للعمود الأول من الصف الثاني
    tbl[0, 1].TextFrame.Text = "جديد";

    // حفظ العرض المعدل إلى القرص
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **محاذاة النص في الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. أضف كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) من [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
6. قم بمحاذاة النص عموديًا.
7. احفظ العرض المعدل.

هذا الكود C# يوضح لك كيفية محاذاة النص في جدول:

```c#
// أنشئ مثيلًا من فئة Presentation
Presentation presentation = new Presentation();

// احصل على الشريحة الأولى
ISlide slide = presentation.Slides[0];

// تحديد الأعمدة بعرضها والصفوف بارتفاعها
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// إضافة شكل الجدول إلى الشريحة
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// الوصول إلى إطار النص
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// إنشاء كائن Paragraph لإطار النص
IParagraph paragraph = txtFrame.Paragraphs[0];

// إنشاء كائن Portion للفقرة
IPortion portion = paragraph.Portions[0];
portion.Text = "نص هنا";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// محاذاة النص عموديًا
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// حفظ العرض إلى القرص
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **تعيين تنسيق النص على مستوى الجدول**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) من الشريحة.
4. تعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للنص.
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. حفظ العرض المعدل.

هذا الكود C# يوضح لك كيفية تطبيق خيارات التنسيق المفضلة لديك على النص في جدول:

```c#
// أنشئ مثيلًا من فئة Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول

// تعيين ارتفاع خط خلايا الجدول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// تعيين محاذاة النص في خلايا الجدول والهامش الأيمن في مكالمة واحدة
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// تعيين نوع النص العمودي في خلايا الجدول
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **الحصول على خصائص نمط الجدول**

تسمح لك Aspose.Slides باسترداد خصائص النمط لجدول حتى تتمكن من استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. هذا الكود C# يوضح لك كيفية الحصول على خصائص النمط من نمط الجدول المعين مسبقًا:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير نمط القالب الافتراضي
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **قفل نسبة عرض إلى ارتفاع الجدول**

نسبة العرض إلى الارتفاع لشكل هندسي هي النسبة بين أحجامه في أبعاد مختلفة. توفر Aspose.Slides خاصية `AspectRatioLocked` للسماح لك بقفل إعداد نسبة العرض إلى الارتفاع للجداول والأشكال الأخرى.

هذا الكود C# يوضح لك كيفية قفل نسبة العرض إلى الارتفاع لجدول:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"تم تعيين قفل نسبة العرض إلى الارتفاع: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // عكس الحالة

    Console.WriteLine($"تم تعيين قفل نسبة العرض إلى الارتفاع: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```