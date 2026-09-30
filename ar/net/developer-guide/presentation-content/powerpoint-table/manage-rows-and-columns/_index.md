---
title: إدارة الصفوف والأعمدة في جداول PowerPoint في .NET
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/net/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس جدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط جدول
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides لـ .NET وتسريع تحرير العروض التقديمية وتحديث البيانات."
---
## **مقدمة**

Aspose.Slides for .NET يتيح لك إدارة بنية الجدول وتنسيقه في عروض PowerPoint من خلال فئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). يمكنك تعيين صف رأس، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف كامل أو عمود كامل.

تشرح هذه المقالة هذه العمليات باستخدام أمثلة C#. كما تُظهر كيفية استرجاع نمط الجدول المسبق حتى يمكنك إعادة استخدامه. مؤشرات الصفوف والأعمدة في الجدول تبدأ من الصفر.

## **التحكم في ارتفاع الصف**

استخدم [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. هو حد أدنى، ليس ارتفاعًا ثابتًا. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) يُرجع الارتفاع الفعلي وهو للقراءة فقط. يمكنك الوصول إلى الصف عبر [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

يقوم المثال بتحميل [row-height-input.pptx](row-height-input.pptx)، الذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. تستخدم الخلايا نص Arial بحجم 18 نقطة، مع التفاف، وهوامش علوية وسفلية 6 نقاط؛ النص الطويل في العمود الثاني يلتف إلى عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يقلّصه إلى 20 نقطة، يطبع الارتفاع الفعلي بعد كل تغيير، ويحفظ كلا النتيجتين.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

مع العرض المرفق، زيادة الحد الأدنى تضيف مساحة إلى الصف. تقليلها يزيل تلك المسافة الزائدة، لكن الارتفاع الفعلي يبقى أكبر من 20 نقطة لأن النص وهوامش الخلية تحتاج مساحة أكبر. لا يمكن لتقليل الحد الأدنى وحده إجبار الصف على أن يكون أقل من المساحة المطلوبة لمحتوياته.

عدة عوامل تؤثر على الارتفاع الفعلي:

- **النص وحجم الخط:** النص الطويل، أو فواصل أسطر صريحة، أو حجم خط أكبر قد يتطلب مساحة عمودية أكبر.
- **اللف وعرض العمود:** عند تمكين اللف، يمكن لعرض [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) الأضيق أن ينتج المزيد من الأسطر. عرض عمود أوسع يمكن أن يقلل المسافة المطلوبة عموديًا.
- **هوامش الخلية:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) و[ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) تضيف مساحة رأسية. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) و[ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) تقلل العرض المتاح للنص ويمكن أن تتسبب في لف إضافي.

في هذا الجدول بدون خلايا مدمجة، الخلية التي تحتاج إلى أكبر مساحة رأسية تحدد الحد الأدنى المدفوع بالمحتوى للصف بأكمله. لجعل الصف أقصر، قد تحتاج أيضًا إلى تقصير النص، تقليل حجم الخط أو الهوامش، أو توسيع عمود.

تُظهر الصور أدناه نفس الجدول بنفس المقياس. في هذه التجربة، كان الارتفاع الفعلي 70، 100، و55.2 نقطة: ظل الصف الأخير أطول من الحد الأدنى البالغ 20 نقطة. يمكن أن تختلف قياسات النص الدقيقة حسب الخطوط المتوفرة في بيئتك. حمل النتائج المحفوظة: [increased minimum](row-height-increased.pptx) و[decreased minimum](row-height-decreased.pptx).

| الأصلي: الحد الأدنى 70 نقطة، الفعلي 70 نقطة | زيادة: الحد الأدنى 100 نقطة، الفعلي 100 نقطة | تقليل: الحد الأدنى 20 نقطة، الفعلي 55.2 نقطة |
| --- | --- | --- |
| ![الجدول الأصلي مع صف أول بارتفاع 70 نقطة.](row-height-before.png) | ![الجدول بعد زيادة الحد الأدنى للصف الأول إلى 100 نقطة.](row-height-increased.png) | ![الجدول بعد تقليل الحد الأدنى للصف الأول إلى 20 نقطة؛ النص الملتف يحافظ على ارتفاع الصف أعلى من الحد الأدنى.](row-height-decreased.png) |

## **تعيين الصف الأول كعنوان**

استخدم خاصية [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) لتحديد الصف الأول لتنسيق العنوان. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. حمّل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. الوصول إلى الجدول المخزن كأول شكل في الشريحة.
4. تمكين تنسيق العنوان للصف الأول.
5. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى. يقوم بتمكين تنسيق العنوان للصف الأول ويحفظ `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **استنساخ صف أو عمود في جدول**

استنسخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إلحاق نسخة في نهاية الجدول أو إدراجها في موضع محدد.

1. حمّل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. حدد عرض الأعمدة وارتفاع الصفوف.
4. أضف جدولًا باستخدام طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. استنسخ الصفوف المطلوبة.
6. استنسخ الأعمدة المطلوبة.
7. احفظ العرض المعدل.

المثال يتطلب `Test.pptx` يحتوي على شريحة واحدة على الأقل. ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يلحق نسخًا من الصف الأول والعمود الأول، ثم يدخل نسخًا من الصف الثاني والعمود الثاني عند الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج بسبعة صفوف وخمسة أعمدة. الوسيط `false` يمنع الاستنساخ إلى الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **إزالة صف أو عمود من جدول**

إزالة الصفوف أو الأعمدة التي لم تعد ضرورية في الجدول. إزالة عنصر تُعيد ضبط مؤشرات الصفوف أو الأعمدة التي تليه.

1. أنشئ عرضًا باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. حدد عرض الأعمدة وارتفاع الصفوف.
4. أضف جدولًا باستخدام طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. أزل الصف الثاني والعمود الثاني.
6. احفظ العرض المعدل.

هذا المثال ينشئ جدولًا ثلاثًا في ثلاثة ويزيل الصف والعمود عند الفهرس 1، تاركًا جدولًا ثنائيًا في `TestTable_out.pptx`. الأبعاد بالنقاط. الوسيط `false` يمنع إزالة الصفوف أو الأعمدة المدمجة المجاورة؛ هذا الجدول لا يحتوي على خلايا مدمجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **تعيين تنسيق النص على مستوى صف الجدول**

تطبيق تنسيق النص على صف كامل للحفاظ على تناسق خلاياه. يمكنك تعيين خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الوصول إلى الجدول في الشريحة الأولى.
3. عيّن [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للصف الأول.
4. عيّن [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) للصف الأول.
5. عيّن [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) للصف الثاني.
6. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل صفين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمنى 20 نقطة على الصف الأول، ثم يعيّن نصًا عموديًا في الصف الثاني.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

تطبيق تنسيق النص على عمود كامل للحفاظ على تناسق خلاياه. يمكنك تعيين خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الوصول إلى الجدول في الشريحة الأولى.
3. عيّن [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للعمود الأول.
4. عيّن [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) للعمود الأول.
5. عيّن [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) للعمود الثاني.
6. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل عمودين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمنى 20 نقطة على العمود الأول، ثم يعيّن نصًا عموديًا في العمود الثاني.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **الحصول على خصائص نمط الجدول**

استخدم خاصية [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) لاسترجاع النمط المسبق المطبق على جدول وإعادة استخدامه على جدول آخر. هذا يحدد النمط المسبق بدلاً من تجاوز تنسيقات الخلايا الفردية.

المثال ينشئ جدولًا، يطبق [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/)، ويقرأ النمط المسبق مرة أخرى. يطبع `DarkStyle1` ويحفظ الجدول في `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئة والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول وفقًا لهذا الترتيب.

**هل يمكنني الحصول على أعمدة متناوبة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المتناوبة، ثم تجاوز خلايا معينة بتنسيق محلي؛ تنسيق الخلية يتفوق على نمط الجدول.