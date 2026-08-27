---
title: "إدارة جداول العروض التقديمية في .NET"
linktitle: "إدارة الجدول"
type: docs
weight: 10
url: /ar/net/manage-table/
keywords:
- "إضافة جدول"
- "إنشاء جدول"
- "الوصول إلى جدول"
- "نسبة الأبعاد"
- "محاذاة النص"
- "تنسيق النص"
- "نمط الجدول"
- PowerPoint
- "عرض تقديمي"
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للـ .NET. اكتشف أمثلة كود C# بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

الجدول في PowerPoint طريقة فعّالة لعرض وتصوير المعلومات. المعلومات في شبكة من الخلايا (المرتبة في صفوف وأعمدة) تكون مباشرة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/net/aspose.slides/table/)، الواجهة [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/)، الفئة [Cell](https://reference.aspose.com/slides/ar/net/aspose.slides/cell/)، الواجهة [ICell](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية.

## **إنشاء جدول من الصفر**

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. عرّف مصفوفة `columnWidth`.
4. عرّف مصفوفة `rowHeight`.
5. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) إلى الشريحة عبر طريقة [AddTable](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addtable/) .
6. كرّر على كل [ICell](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا، السفلية، اليمنى واليسرى.
7. دمج الخلايا الأولى الاثنين في الصف الأول للجدول. 
8. للوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/). 
9. أضف بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/) .
10. احفظ العرض التقديمي المعدّل.

هذا الكود C# يوضح لك كيفية إنشاء جدول في عرض تقديمي:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();

// يصل إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
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
// يدمج الخلايا 1 و 2 من الصف 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// يضيف بعض النص إلى الخلية المدمجة
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// يحفظ العرض التقديمي على القرص
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **الترقيم في جدول قياسي**

في جدول قياسي، ترقيم الخلايا مباشر ويبدأ من الصفر. الخلية الأولى في الجدول تُرقم كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول مكوّن من 4 أعمدة و4 صفوف بهذه الصيغة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا الكود C# ينشئ جدولًا قياسيًا 4 × 4 بالترقيم أعلاه ويضبط تنسيق الحدود لكل خلية:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يحدد الأعمدة بعرضها والصفوف بارتفاعها
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

    // يحفظ العرض التقديمي على القرص
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى جدول موجود**

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. احصل على مرجع الشريحة التي تحتوي على الجدول من خلال فهرسها. 
3. أنشئ كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) وعيّن قيمته `null`. 
4. كرّر عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تعتقد أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم التعرف على شكل على أنه جدول، يمكنك تحويل النوع إلى كائن [Table](https://reference.aspose.com/slides/ar/net/aspose.slides/table/) . أما إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر خاصية [AlternativeText](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/alternativetext/) الخاصة به.

5. استخدم كائن [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.
6. احفظ العرض التقديمي المعدّل.

هذا الكود C# يوضح لك كيفية الوصول إلى جدول موجود والعمل معه:

```c#
using Aspose.Slides;

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يهيئ TableEx إلى null
    ITable tbl = null;

    // يتنقل عبر الأشكال ويضع مرجعًا للجدول المكتشف
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // يحدد النص للعمود الأول من الصف الثاني
    tbl[0, 1].TextFrame.Text = "New";

    // يحفظ العرض التقديمي المعدل على القرص
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **العثور على الخلية التي تملك إطار نص**

عند استلام كود معالجة نص عام كائن [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) من جدول، استخدم الخاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) لاسترجاع الـ [ICell](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/) المالكة. بالنسبة لإطار نص داخل خلية جدول، تُعيّن الخاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) وتكون الخاصية [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/) `null`، رغم أن الجدول نفسه يُعد شكلاً.

إحداثيات الخلية متاحة عبر الخاصيتين للقراءة فقط [ICell.FirstColumnIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/firstcolumnindex/) و[ICell.FirstRowIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/firstrowindex/). كما أن الخاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) للقراءة فقط: فهي تُوفر التنقل إلى المالك دون تعديل الملكية. احرص دائمًا على فحص ما إذا كانت الخلية المرجعة `null` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعناصر SmartArt، راجع [Search and Replace Text](/slides/ar/net/search-and-replace-text/).

## **محاذاة النص داخل جدول**

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. أضف كائنًا من النوع [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) إلى الشريحة. 
4. احصل على كائن [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) من الجدول. 
5. احصل على [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) الخاص بـ [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) .
6. محاذاة النص عموديًا.
7. احفظ العرض التقديمي المعدّل.

هذا الكود C# يوضح لك كيفية محاذاة النص داخل جدول:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائنًا من فئة Presentation
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

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **ضبط تنسيق النص على مستوى الجدول**

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. احصل على كائن [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) من الشريحة.
4. اضبط خاصية [FontHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/fontheight/) للنص. 
5. اضبط [Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/marginright/) . 
6. اضبط [TextVerticalType](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/textverticaltype/) .
7. احفظ العرض التقديمي المعدّل. 

هذا الكود C# يوضح لك كيفية تطبيق خيارات التنسيق المفضلة على النص داخل جدول:

```c#
using Aspose.Slides;

// ينشئ كائنًا من فئة Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يضبط ارتفاع خط خلايا الجدول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// يضبط محاذاة نص خلايا الجدول والهوامش اليمنى في استدعاء واحد
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// يضبط نوع الاتجاه العمودي للنص في خلايا الجدول
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **الحصول على خصائص نمط الجدول**

تتيح لك Aspose.Slides استرداد خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود C# كيفية الحصول على خصائص النمط من نمط جدول مُعد مسبقًا:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير نمط الإعداد الافتراضي

    // احصل على نمط الإعداد للجدول.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // تطبيق نمط الإعداد المسترجع على جدول آخر.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **قفل نسبة الأبعاد للجدول**

نسبة أبعاد الشكل الهندسي هي نسبة أحجامه في أبعاد مختلفة. توفر Aspose.Slides الخاصية `AspectRatioLocked` لتتيح لك قفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى. 

هذا الكود C# يوضح لك كيفية قفل نسبة الأبعاد لجدول:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // عكس

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفّر الجدول الخاصية [RightToLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/table/righttoleft/) ، وتملك الفقرات الخاصية [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/paragraphformat/righttoleft/) . استخدامهما معًا يضمن الترتيب والعرض الصحيح للـ RTL داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، وغيرها. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يُدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفق الوضع المحدد (تمدد أو تجانس).