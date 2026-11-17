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

Aspose.Slides يتيح لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. توضح هذه المقالة كيفية التعرف على الخلايا المدمجة في الجداول، وإزالة حدود الخلايا، والعمل مع ترقيم الخلايا بعد الدمج أو التقسيم، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية الجدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس ذات قاعدة الصفر للوصول إلى خلايا الجداول بترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجود ويصل إلى الشكل الأول في الشريحة الأولى باعتبارها جدولًا. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتنقل عبر جميع الصفوف والأعمدة ويستخدم [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، و[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)، و[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)، وإحداثيات بداية المنطقة، و[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) و[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

إنشاء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع الحدود الأربعة للخلايا إلى [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **إضافة حدود قطرية للخلية**

استخدم [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) لرسم خط من الزاوية العلوية اليسرى إلى الزاوية السفلية اليمنى، واستخدم [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) لرسم خط من الزاوية السفلية اليسرى إلى الزاوية العلوية اليمنى. يمكن للقطرية أن تشير إلى رأس زاوية؛ ويمكن للقطرين معًا تشكيل X لتحديد الخلية كغير صالحة.

كل قطرية هي [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). في [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) الخاص بها، اضبط [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) واختر [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). اضبط [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) للخط بالنقاط.

ينشئ المثال ثلاثة خلايا في صف واحد: قطرية سفلية حمراء، قطرية علوية زرقاء، وكلا القطرين. يترك حدود الخلية العلوية والسفلية واليسرى واليمنى دون تغيير.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

القطرية هي خاصية تنسيق، ليست تقسيمًا للخلية. تحتفظ كل خلية بـ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) واحد؛ لا يمكن تحرير المناطق على جانبي القطرية بشكل مستقل.

الجدول المحفوظ، معروض في Microsoft PowerPoint:

![ثلاث خلايا جدول تُظهر قطرية حمراء من أعلى اليسار إلى أسفل اليمين، قطرية زرقاء من أسفل اليسار إلى أعلى اليمين، وكلا القطرين يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطرية سفلية (أحمر، 3 pt)، قطرية علوية (أزرق، 5 pt)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العلوية اليسرى والسفلية اليمنى للنطاق. المتغير الأخير يتحكم فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يحافظ على دمج داخل ذلك النطاق فقط.

ينشئ المثال جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عبر عمودين وصفين، بينما يبقى شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موضعها العلوي الأيسر: `table[1, 1]` في هذا المثال. تظل المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

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

الحفاظ على شبكة الجدول يحدث عند دمج الخلايا كما هو موضح في المثال السابق. تقسيم خلية قد يُدخل عمود شبكة جديدًا ويغيّر فهارس الأعمدة للخلية التي على يمينها. يتبع Aspose.Slides نموذج شبكة جدول PowerPoint.

ينشئ هذا المثال جدولًا 4×4 بأعمدة وصفوف عرضها 70 نقطة ويستدعي [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) على الخلية `(1, 1)`. نصف عرض الخلية البالغ 70 نقطة يُمرَّر لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، تُؤخذ النصفان كـ `table[1, 1]` و`table[2, 1]`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا التي كانت في العمودين 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تبقى فهارس الصفوف دون تغيير. استخدم فهارس الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

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

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) للتقسيم على طول حد صف موجود، أو [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) للتقسيم على طول حد عمود.

حجة `index` تعد الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهي نسبية إلى المنطقة المدمجة:

- تقسيم صف: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- تقسيم عمود: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

يفترض المثال وجود عرض تقديمي يحتوي على جدول كأول شكل في أول شريحة، حيث تم دمج الخلايا `(1, 2)` و`(1, 3)` عموديًا. يبدأ من الموضع السفلي، يستخدم [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) و[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) لتحديد الأصل ويفحص كلا الامتدادين. ثم يُنفّذ `SplitByRowSpan(1)` لفصل الصفين 2 و3 لأسماء المنتجات. للدمج الأفقي ذو عمودين، استخدم `SplitByColSpan(1)` بدلاً من ذلك.

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

تبقى شبكة الجدول والفهارس المجاورة للخلايا دون تغيير. استرجع الخلايا الناتجة عبر إحداثياتها؛ هنا، كلاهما يمتدان بمدى 1 وتطبع [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) قيمة `False`. قد تظل مناطق أكبر مدمجة جزئيًا بعد تقسيم واحد.

النص الأصلي وتنسيقه يبقى في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهوامش. عبّئ الخلايا بعد التقسيم واضبط أي تنسيق نصي مطلوب صراحةً.

العرض المحفوظ يحتوي على خلايا "Product A" و"Product B" منفصلة مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) لمزيد من التفاصيل.


<!-- visual-explanation:manage-cells:start -->
[![الخلية المدمجة في العمود 1، الصفوف 2 و3 تنقسم إلى Product A وProduct B مع نفس فهارس الشبكة.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*استخدام تقسيم امتداد الصف يستند إلى الحد الموجود. تشغل خلايا Product A وProduct B الموضعين (1, 2) و(1, 3) على التوالي.* 
<!-- visual-explanation:manage-cells:end -->

### **تقسيم خلية بارتفاع محدد**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) يأخذ ارتفاع الجزء العلوي بالنقاط. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) يأخذ عدد الصفوف الشبكية الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من الارتفاع الفعلي للخلية ووزّع المساحة المتبقية بالتساوي فوقها وتحتها.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

الإضافة الأولى للتقسيم تضيف صف شبكة، وتترك الـ90 نقطة السفلية في `[1, 1]`. التقسيم الثاني يستهدف تلك الخلية ويضيف صفًا آخر أسفلها. الآن يحتوي العمود الأيمن على `[1, 0]` بارتفاع 50 نقطة (`margin`)، و`[1, 1]` بارتفاع 40 نقطة، و`[1, 2]` بارتفاع 50 نقطة (`margin`). الخلية اليسرى تمتد عبر الثلاثة صفوف بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد على كامل ارتفاع الجدول بجوار ثلاث خلايا ذات وسط في الوسط.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

ينشئ هذا المثال جدولًا بأعمدة عرضها 150 نقطة وصفوف بارتفاع 50 نقطة. يضبط [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى صلب و[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) إلى الأحمر للخلية `(2, 3)`، في العمود الثالث والصف الرابع.

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

ضع صورة الإدخال في الدليل العامل قبل تشغيل هذا المثال. يتم تحميل الصورة باستخدام [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) وتضيفها إلى مجموعة صور العرض باستخدام [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). ثم تُعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, أول خلية في الجدول.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) يمدّد الصورة لملء الخلية، مما قد يغيّر نسبة العرض إلى الارتفاع. أعرض الأعمدة وارتفاع الصفوف بالنقاط. تُصرف الصورة المحملة تلقائيًا بفضل بيان `using`.

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

**هل يمكنني ضبط سماكات وأنماط خطوط مختلفة لجوانب مختلفة من خلية واحدة؟**

نعم. حدود [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). مع التمدد، تضبط الصورة لتتناسب مع الخلية الجديدة؛ ومع التبليط، تُعاد حساب البلاط.

**هل يمكنني ربط جميع محتوى خلية برابط تشعبي؟**

[Hyperlinks](/slides/ar/net/manage-hyperlinks/) تُضبط على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بالكامل. عمليًا، تُعيّن الرابط إلى جزء أو إلى كل النص داخل الخلية.

**هل يمكنني ضبط خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (المقاطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.