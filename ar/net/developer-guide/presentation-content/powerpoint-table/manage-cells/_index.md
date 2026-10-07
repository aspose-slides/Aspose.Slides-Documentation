---
title: إدارة خلايا الجداول في العروض التقديمية باستخدام .NET
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/net/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم خلية
- صورة داخل خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة خلايا جداول PowerPoint في C#: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بالوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. يشرح هذا المقال كيفية تحديد خلايا الجداول المدمجة، إزالة حدود الخلايا، العمل مع ترقيم الخلايا بعد دمج أو تقسيم الخلايا، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

يستخدم Aspose.Slides مؤشرات تبدأ من الصفر للوصول إلى خلايا الجداول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرضًا تقديميًا موجودًا ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يتكرر عبر جميع الصفوف والأعمدة ويستخدم [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)، [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)، وإحداثيات بدء المنطقة، [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) و[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **إزالة حدود خلايا الجدول**

أنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وأضف جدولًا إلى الشريحة الأولى باستخدام [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). يتم تحديد عرض الأعمدة وارتفاع الصفوف وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلايا الأربعة إلى [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)، مما يجعلها غير مرئية.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **دمج خلايا الجدول**

استخدم [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاوية العليا اليسرى والزاوية السفلى اليمنى للنطاق. المتغير الأخير يتحكم فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يحافظ على الدمج داخل ذلك النطاق.

ينشئ المثال جدولًا 4×4 بأعمدة وارتفاعات 70 نقطة، ثم يدمج الخلايا الأربعة المركزية من `(1, 1)` إلى `(2, 2)`. تمتد الخلية الناتجة عبر عمودين وصفين، بينما يبقى الشبكة الأساسية للجدول بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها الأعلى الأيسر: `table[1, 1]` في هذا المثال. تظل المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير مؤشرات الخلايا خارج النطاق.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **تقسيم خلايا الجدول**

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. يمكن أن يُدخل تقسيم خلية عمودًا جديدًا في الشبكة ويغيّر مؤشرات الأعمدة للخلايا الموجودة إلى يمينه. يتبع Aspose.Slides نموذج شبكة الجداول في PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وارتفاعات 70 نقطة ويستدعي [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) على الخلية `(1, 1)`. يُمرَّر نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، تُستَخدم النصفان كـ `table[1, 1]` و`table[2, 1]`. الآن تحتوي شبكة الجدول على خمسة أعمدة: تنتقل الخلايا التي كانت في الأعمدة 2 و3 إلى الأعمدة 3 و4 على التوالي. تظل مؤشرات الصفوف دون تغيير. استخدم مؤشرات الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لملء البيانات، استخدم [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) لتقسيم على طول حد الصف الموجود، أو [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) لتقسيم على طول حد العمود.

عدد `index` يعدّ الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبي للمنطقة المدمجة:

- تقسيم الصف: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- تقسيم العمود: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في الشريحة الأولى، مع دمج رأسي بين `(1, 2)` و`(1, 3)`. يبدأ من الموضع الأسفل، يستخدم [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) لتحديد الأصل ويفحص كلا الامتدادين. ثم `SplitByRowSpan(1)` يفصل الصفين 2 و3 لأسماء المنتجات. لدمج أفقي من عمودين، استخدم `SplitByColSpan(1)` بدلاً من ذلك.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

تبقى شبكة الجدول ومؤشرات الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة بواسطة إحداثياتها؛ هنا، كلاهما يمتد بـ 1 وتطبع [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) القيمة `False`. يمكن أن تظل المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العليا (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها تورث تنسيق الخلية مثل الملء والحدود والهوامش. املأ الخلايا بعد التقسيم وحدد أي تنسيق نصي مطلوب صراحةً.

يحتوي العرض المحفوظ على خلايا "Product A" و"Product B" منفصلة مع الحفاظ على تنسيق خلايا القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) للمزيد من التفاصيل.

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يحدد [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى صلب و[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في الدليل العامل قبل تشغيل هذا المثال. يحمل المثال الصورة باستخدام [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) ويضيفها إلى مجموعة صور العرض باستخدام [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). ثم يُعيّن الصورة إلى ملء الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) يمدّ الصورة لتملأ الخلية، مما قد يغيّر نسبة أبعادها. عرض الأعمدة وارتفاع الصفوف بالنقاط. تُفكّ صورة التحميل تلقائيًا بواسطة بيان using الخاص بها.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **الأسئلة الشائعة**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/ar/net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.