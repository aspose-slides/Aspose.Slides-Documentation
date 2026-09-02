---
title: الحصول على خصائص الشكل الفعالة من العروض التقديمية في .NET
linktitle: خصائص فعالة
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام إضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides لـ .NET للتفريق بين تنسيق الشكل المحلي والموروث والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والموروثة والفعالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على الكائن هي **القيمة المحلية**. إذا لم يتم تعيين هذه القيمة، يبحث PowerPoint عن مصادر تنسيق أصلية، مثل افتراضية الفقرة، نمط النص، تخطيط أو شريحة رئيسية، سمة، أو إعدادات افتراضية على مستوى العرض. تلك القيم هي **القيم الموروثة**. القيمة التي تظل بعد حل كامل الهرم هي **القيمة الفعالة** – القيمة المستخدمة لتصيير الكائن.

على سبيل المثال، قد لا يحدد جزء النص ارتفاع الخط الخاص به. يكون محليًا [FontHeight](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fontheight/) عندئذٍ `float.NaN`، وهو ما يعني "غير محدد هنا". يمكن للجزء أن يرث الارتفاع من الفقرة، أو نمط النص الافتراضي للعرض، أو مصدر مناسب آخر. استدعاء [GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/geteffective/) على تنسيق الجزء يُعيد الارتفاع النهائي المحل.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تعديل كائن تنسيق محلي، مثل [IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/)، عندما تحتاج إلى التحكم في مكان تعريف القيمة.
- قراءة كائن بيانات فعالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformateffectivedata/)، عندما تحتاج إلى النتيجة النهائية المصورة. البيانات الفعالة للقراءة فقط.

## **مقارنة القيم المحلية والموروثة والفعالة**

المثال الكامل التالي ينشئ شكلًا ويطبق ارتفاعات الخط على مستوى العرض، والفقرة، والجزء. كل خطوة تطبع القيم المعرفة في تلك المستويات والقيمة الفعالة الناتجة لنفس جزء النص. كما يوضح لماذا يجب قراءة البيانات الفعالة مرة أخرى بعد تغييرات التنسيق.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// تعريف القيم الموروثة على مستويين مختلفين.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// القيمة المحلية في الجزء تتجاوز القيم الموروثة كلاهما.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// تغيير قيمة موروثة لا يتجاوز قيمة محلية موجودة.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// مسح القيمة المحلية. الآن الجزء يرث من الفقرة مرة أخرى.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// مسح قيمة الفقرة. الآن الافتراضي للعرض يزود النتيجة.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // قراءة البيانات الفعالة بعد التغييرات السابقة.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

الأولوية في هذا المثال هي تنسيق الجزء المحلي، ثم تنسيق الفقرة، ثم الافتراضي للعرض. يمكن لكائنات أخرى أن تكون لها سلاسل وراثة مختلفة، لكن المبدأ نفسه: القيمة الصريحة الأكثر تحديدًا هي التي تنتصر، و[GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/geteffective/) تُعيد النتيجة النهائية.

## **الحصول على خصائص النص الفعالة**

تنقسم تنسيقات النص عبر عدة كائنات:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/geteffective/) يحل خصائص إطار النص مثل الهوامش، التثبيت، الملاءمة التلقائية، واتجاه النص الرأسي.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/ar/net/aspose.slides/itextstyle/geteffective/) يحل تنسيق الفقرة لكل مستوى من مستويات نمط النص.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/geteffective/) يحل خصائص الفقرة مثل المحاذاة، المسافات البادئة، والنقاط.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/geteffective/) يحل خصائص الحرف مثل ارتفاع الخط، نوع الخط، اللون، العريض، والمائل.

في المثال التالي، يجب أن يحتوي الملف `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) واحد يحتوي على إطار نص غير فارغ. يمكن أن تظهر الـ AutoShape في أي موضع ضمن مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويتحقق منه قبل الاستخدام.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **الحصول على خصائص 3D الفعالة**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/geteffective/) يُعيد عنصر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/) واحد يجمع جميع إعدادات 3D المحلّة. تعرض خصائصه [Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/camera/)، [LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/lightrig/)، [BevelTop](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/beveltop/)، و[BevelBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) البيانات الفعالة المقابلة. قراءة هذه الإعدادات المرتبطة معًا يجعل من السهل فهم المظهر 3D النهائي للشكل.

لهذا المثال، يجب أن يحتوي الملف `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. طبّق إعدادات كاميرا 3D أو إضاءة أو حافة لهذا الشكل إذا كنت تريد أن يحتوي الناتج على قيم غير القيم الافتراضية.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **الحصول على تنسيق الجدول الفعال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول بأكمله أو على عمود أو صف أو خلية فردية. في حالة التعارض بين التعبئات المعرفة صراحةً، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بالكامل. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

في هذا المثال، يجب أن يحتوي الملف `table-formatting.pptx` على جدول واحد على الأقل في شريحته الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد على الأقل. يبحث الكود عن [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/) بدلاً من افتراض أن `Shapes[0]` هو جدول.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

إذا كنت تحتاج إلى اللون بدلاً من نوع التعبئة فقط، فابدأ بفحص [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/filltype/) الفعّال، ثم اقرأ الخاصية التي تنطبق على ذلك النوع؛ على سبيل المثال، [SolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) لتعبئة صلبة.

## **إعادة قراءة البيانات الفعالة بعد التغييرات**

البيانات الفعالة تصف هرمية التنسيق في وقت حلها. استدعِ `GetEffective` مرة أخرى بعد تغيير أي شيء يمكن أن يشارك في تلك الهرمية، بما في ذلك:

- تنسيق الكائن المحلي؛
- افتراضيات الفقرة أو إطار النص؛
- نمط جدول أو جدول أو عمود أو صف أو تنسيق خلية؛
- تنسيق تخطيط أو شريحة رئيسية؛
- بيانات السمة أو الافتراضيات على مستوى العرض؛
- التخطيط أو الشريحة الرئيسية المعيّنة لشريحة معينة.

لا تحتفظ بكائن بيانات فعّال كلقطة ثابتة. قد تقوم Aspose.Slides بتخزين بعض البيانات الفعالة مؤقتًا داخليًا، ويمكن لاستدعاء `GetEffective` لاحقًا تجديد تلك البيانات. إذا كنت بحاجة إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم القياسية التي تحتاجها—مثل ارتفاع الخط أو اللون أو المحاذاة أو عرض الحافة—إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `GetEffective` للتحقق من النتيجة. كائنات البيانات الفعالة نفسها للقراءة فقط.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أي مستوى قدم قيمة فعالة؟**

البيانات الفعالة تحتوي على القيمة النهائية، لا مصدرها. تفقد الكائنات المحلية القابلة للتطبيق بدءًا من المستوى الأكثر تحديدًا outward. بالنسبة للنص، قد يشمل ذلك الجزء، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، السمة، وإعدادات الافتراضية للعرض. القيم غير المعرفة مثل `float.NaN` أو `null` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث إذا لم يحدد أي مستوى خاصية؟**

تقوم Aspose.Slides بحل القيمة الافتراضية المناسبة في PowerPoint أو في المكتبة. تظهر تلك القيمة المحلَّة في البيانات الفعالة رغم عدم تعريف أي كائن محلي لها صراحةً.

**لماذا أحيانًا تكون القيمة الفعالة مساوية للقيمة المحلية؟**

القيمة المحلية فازت في حساب الوراثة. هذا متوقع عندما يتم تعيين الخاصية صراحةً على الكائن ولا يتجاوزها أي قاعدة أكثر تحديدًا.

**متى يجب أن أستخدم البيانات المحلية بدلاً من البيانات الفعالة؟**

استخدم البيانات المحلية لتفقد أو تعديل مستوى تنسيق معين. استخدم البيانات الفعالة عندما تحتاج إلى المظهر النهائي بعد تطبيق الوراثة وقواعد السمة والأنماط المطبقة. يوضح مثال [المقارنة الكامل](#compare-local-inherited-and-effective-values) كلا الحالتين في سير عمل واحد.