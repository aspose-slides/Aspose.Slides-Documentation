---
title: "إدارة جداول العروض التقديمية في .NET"
linktitle: "إدارة الجدول"
type: docs
weight: 10
url: /ar/net/manage-table/
keywords:
- "إضافة جدول"
- "إنشاء جدول"
- "الوصول إلى الجدول"
- "نسبة الأبعاد"
- "محاذاة النص"
- "تنسيق النص"
- "نمط الجدول"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET. اكتشف أمثلة بسيطة بلغة C# لتيسير عمليات الجدول الخاصة بك."
---
## **المقدمة**

تنظم الجداول في PowerPoint المعلومات في صفوف وأعمدة، مما يجعل من السهل قراءة القيم ومقارنتها.

توفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) وفئة [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) وواجهة [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء الجداول وتحديثها وإدارتها في العروض التقديمية.

## **إنشاء جدول من الصفر**

أنشئ جدولًا بتحديد موقعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى الشريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج النص.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة بواسطة فهرسها.
3. عرّف مصفوفة من عرض الأعمدة بالنقاط.
4. عرّف مصفوفة من ارتفاع الصفوف بالنقاط.
5. أضف كائنًا من نوع [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. استعرض كل [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) لتطبيق تنسيق على الحدود العليا والسفلى واليمينية واليسرى.
7. دمج الخليتين الأوليين في الصف الأول للجدول.
8. احصل على الخلية المدمجة من خلال خاصية [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. عيّن النص في الخلية المدمجة.
10. احفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف عند النقطة (100, 50). يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليين في الصف الأول، ويحفظ النتيجة كملف `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **ترقيم في جدول قياسي**

في جدول قياسي، تكون فهارس الخلايا صفرية وتُستخدم الصيغة (عمود, صف). تُرقم أول خلية كـ (0, 0).

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف قدره 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. تُظهر الإحداثيات فهارس الخلايا؛ يترك المثال الخلايا فارغة ويحفظ الجدول كملف `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **الوصول إلى جدول موجود**

تُخزن الجداول في مجموعة الأشكال الخاصة بالشريحة. استعرض الأشكال لتحديد جدول، ثم استخدم واجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) لقراءة خلاياه أو تحديثها.

1. حمّل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة التي تحتوي على الجدول بواسطة فهرسها.
3. استعرض كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) وتوقف عند العثور على جدول. إذا احتوت الشريحة على عدة جداول، استخدم خاصية [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) لتحديد الجدول المطلوب.
4. حدّث النص في الخلية المستهدفة.
5. احفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `UpdateExistingTable.pptx` ويجد أول جدول على الشريحة الأولى. يعيّن الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة كملف `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، ويجب أن يحتوي الجدول الأول على عمود واحد على الأقل وصفين.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

لتغيير حجم صف في جدول موجود وفهم سبب تجاوز ارتفاعه الفعلي للحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/net/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تملك إطار نص**

عند استقبال شفرة معالجة نص عامة لكائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) من جدول، استخدم خاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) لاسترداد [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) المالك. بالنسبة لإطار نص خلية جدول، تُحدد خاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) وتكون خاصية [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) `null`، رغم أن الجدول نفسه يُعتبر شكلاً.

تتوفر إحداثيات الخلية عبر الخاصيتين القابلتين للقراءة فقط [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و[ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). خاصية [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) هي أيضًا للقراءة فقط: توفر التنقل إلى المالك دون تغيير الملكية. تحقق دائمًا من أن الخلية المرجعية ليست `null` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجداول والأشكال، بما في ذلك الأشكال المرتبطة بعناصر SmartArt، راجع [Search and Replace Text](/slides/ar/net/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في التثبيت العمودي واتجاه النص لخلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويدورها بزاوية 270 درجة.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة بواسطة فهرسها.
3. أضف كائنًا من نوع [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة.
4. احصل على كائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) من الجدول.
5. احصل على أول [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) واضبط نصه ولونه.
6. اضبط خاصيتَي [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) و[TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/).
7. احفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدولًا 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة كملف `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **تعيين تنسيق النص على مستوى الجدول**

استخدم [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) لتطبيق تنسيق النص على جميع خلايا الجدول. تتقبل التحميلات تنسيقات الجزء والفقرة وإطار النص، لذا يمكنك ضبط هذه الخصائص دون استعراض الخلايا فرديًا.

1. حمّل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة بواسطة فهرسها.
3. احصل على كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) من الشريحة.
4. اضبط خاصية [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للنص.
5. اضبط خاصيتي [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. اضبط خاصية [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. احفظ العرض التقديمي المعدل.

المثال أدناه يفتح الملف `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل وشكل جدول كأول شكل. يضبط حجم الخط إلى 25 نقطة، يحقّق محاذاة فقرة إلى اليمين بهامش يميني 20 نقطة، ويجعل النص عموديًا. تُحفظ النسخة المُنسّقة كملف `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **الحصول على خصائص نمط الجدول**

استخدم [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) لقراءة أو تعيين نمط جدول مسبق. يطبق هذا المثال [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) على جدول واحد، يطبع اسم النمط المسبق، ويعيّن نفس النمط لجدول ثانٍ. يُحفظ كلا الجدولين في الملف `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **قفل نسبة أبعاد الجدول**

نسبة أبعاد الجدول هي نسبة عرضه إلى ارتفاعه. استخدم [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) لقفل هذه النسبة للجدول.

المثال أدناه يفتح الملف `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل وشكل جدول كأول شكل. يطبع الحالة الحالية للقفل، يفعّل قفل نسبة الأبعاد، يطبع الحالة المحدثة (`True`)، ويحفظ النتيجة كملف `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**هل يمكنني تفعيل اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يعرض الجدول خاصية [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/)، وتحتوي الفقرات على خاصية [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). يضمن استخدامهما معًا الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/net/applying-protection-to-presentation/) لتعطيل التحريك، تغيير الحجم، التحديد، إلخ. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) لخلية؛ ستغطي الصورة مساحة الخلية وفق الوضع المختار (تمديد أو تجانب).