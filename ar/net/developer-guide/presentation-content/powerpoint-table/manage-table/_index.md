---
title: إدارة جداول العرض التقديمي في .NET
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/net/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET. اكتشف أمثلة كود C# بسيطة لتبسيط سير عمل الجداول الخاصة بك."
---

جدول في PowerPoint هو طريقة فعّالة لعرض وتوضيح المعلومات. المعلومات في شبكة من الخلايا (مرتّبة في صفوف وأعمدة) مباشرة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) والفئة [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية. 

## **إنشاء جدول من الصفر**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تحديد مصفوفة `columnWidth`.
4. تحديد مصفوفة `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمنى واليسرى.
7. دمج الخليتين الأوليتين في الصف الأول من الجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) . 
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) .
10. حفظ العرض التقديمي المعدل.

This C# code shows you how to create a table in a presentation:
```c#
// يُنشئ كائنًا من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();

// يصل إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// يعرّف الأعمدة بالأعرض والصفوف بالأارتفاعات
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// يضيف شكل جدول إلى الشريحة
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// يضبط تنسيق الحدود لكل خلية
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
// يدمج الخلايا 1 و2 في الصف 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// يضيف بعض النص إلى الخلية المدموجة
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// يحفظ العرض التقديمي إلى القرص
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **الترقيم في الجدول القياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويبدأ من الصفر. الخلية الأولى في الجدول تُعطى الفهرس 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C# code shows you how to specify the numbering for cells in a table:
```c#
 // ينشئ كائن من فئة Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يعرّف الأعمدة بعرضها والصفوف بارتفاعها
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

    // يحفظ العرض التقديمي إلى القرص
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```


## **الوصول إلى جدول موجود**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع للشريحة التي تحتوي على الجدول عبر فهرسها. 
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) وتعيينه إلى null.
4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشتبه أن الشريحة التي تتعامل معها تحتوي على جدول واحد، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل كجدول، يمكنك تحويله إلى كائن [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) . لكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول الذي تحتاجه عبر خاصية [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) الخاصة به.
5. استخدام كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. حفظ العرض التقديمي المعدل.

This C# code shows you how to access and work with an existing table:
```c#
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // تهيئة TableEx بقيمة null
    ITable tbl = null;

    // التكرار عبر الأشكال وتعيين مرجع للجدول الموجود
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // تعيين النص للعمود الأول من الصف الثاني
    tbl[0, 1].TextFrame.Text = "New";

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **محاذاة النص في جدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة. 
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) من الجدول. 
5. الوصول إلى [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) .
6. محاذاة النص بشكل عمودي.
7. حفظ العرض التقديمي المعدل.

This C# code shows you how to align the text in a table:
```c#
// ينشئ مثيلًا لفئة Presentation
Presentation presentation = new Presentation();

// يحصل على الشريحة الأولى
ISlide slide = presentation.Slides[0];

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// يضيف شكل الجدول إلى الشريحة
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// يصل إلى إطار النص
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// ينشئ كائن الفقرة لإطار النص
IParagraph paragraph = txtFrame.Paragraphs[0];

// ينشئ كائن الجزء للفقرة
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// يضبط محاذاة النص عموديًا
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// يحفظ العرض التقديمي إلى القرص
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) من الشريحة.
4. تعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للنص. 
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. حفظ العرض التقديمي المعدل. 

This C# code shows you how to apply your preferred formatting options to the text in a table:
```c#
// ينشئ مثيلًا لفئة Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يضبط ارتفاع الخط لخلايا الجدول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// يضبط محاذاة النص والهوامش اليمنى لخلايا الجدول في استدعاء واحد
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// يضبط نوع النص العمودي لخلايا الجدول
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. This C# code shows you how to get the style properties from a table preset style: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير سمة الإعداد المسبق الافتراضية 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **قفل نسبة الأبعاد للجدول**

نسبة الأبعاد لشكل هندسي هي نسبة أبعاده في أبعاد مختلفة. قدمت Aspose.Slides خاصية `AspectRatioLocked` لتتيح لك قفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى. 

This C# code shows you how to lock the aspect ratio for a table:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // عكس

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يتيح الجدول خاصية [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) ، وتملك الفقرات خاصية [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). باستخدام كلاهما يتم ضمان الترتيب والعرض الصحيح من اليمين إلى اليسار داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، الاختيار، إلخ. تنطبق هذه الأقفال على الجداول أيضًا.

**هل يتم دعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).