---
title: الحصول على الخصائص الفعالة للأشكال من العروض التقديمية في .NET
linktitle: الخصائص الفعالة
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز الإضاءة
- حافة الشكل
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لـ .NET بحساب وتطبيق الخصائص الفعالة للأشكال لضمان عرض PowerPoint بدقة."
---
## **نظرة عامة**

يوضح هذا الموضوع الفرق بين الخصائص **المحلية** و **الفعالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة رئيسية، عندما يحتوي شكل إطار نص الجزء على أحدها.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها على أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعالة**. يمكنك الحصول عليها عن طريق استدعاء طريقة `GetEffective` على كائن التنسيق المحلي.

يظهر المثال التالي كيفية الحصول على القيم الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
تمثل بيانات التنسيق الفعالة التنسيق الحالي المحسوب بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعالة داخليًا في الذاكرة المؤقتة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformateffectivedata/). قد يؤدي استدعاء `GetEffective` مرة أخرى بعد تغيير التنسيق الأب أو الوراثي إلى تحديث البيانات المخزنة مؤقتًا، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعالة لإعادة استخدامها لاحقًا، فانسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعالة للكاميرا. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعالة. يتم عرض نسخة من [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة للكاميرا. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **الحصول على الخصائص الفعالة لجهاز الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعالة لجهاز الإضاءة. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعالة. يتم عرض نسخة من [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة لجهاز الإضاءة. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **الحصول على الخصائص الفعالة لحد الحواف الشكلية**

تتيح لك Aspose.Slides الحصول على الخصائص الفعالة لحد الحواف الشكلية. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الحافة الفعالة للشكل. يتم عرض نسخة من [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعالة للحد العلوي لشكل. يفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **الحصول على الخصائص الفعالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعالة لإطار النص. تحتوي الواجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **الحصول على الخصائص الفعالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعالة لنمط النص. تحتوي الواجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعالة.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **الحصول على قيمة ارتفاع الخط الفعال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعال. يوضح المثال التالي كيف يتغير ارتفاع الخط الفعال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **الحصول على تنسيق التعبئة الفعال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعال لأجزاء مختلفة من الجدول. تحتوي الواجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض مثال الشيفرة التالي كيفية الحصول على تنسيق التعبئة الفعال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول على الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **الأسئلة المتكررة**

**هل تُعيد `GetEffective` لقطة؟**

ليس دائمًا. تمثل البيانات الفعالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعالة قد تُخزن مؤقتًا داخليًا. قد يؤدي استدعاء `GetEffective` لاحقًا إلى إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا يجب اعتبار الكائن المسترجع مسبقًا لقطة ثابتة.

**متى ينبغي قراءة الخصائص الفعالة مرة أخرى؟**

استدعِ `GetEffective` مرة أخرى بعد تعديل التنسيق المحلي أو أنماط الوالد، أو تنسيق التخطيط، أو تنسيق الرئيس، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيُعيد الاستدعاء التالي تقييم شجرة التنسيق ويُعيد النتيجة الفعالة الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعالة التي تم استرجاعها مسبقًا؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `GetEffective`. إذا تم تغيير أو إزالة مصدر تنسيق أب، قد تصبح البيانات الفعالة المسترجعة سابقًا قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تُعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

**هل يمكن تعديل القيم عبر كائنات البيانات الفعالة؟**

لا. كائنات البيانات الفعالة تُظهر القيم المحسوبة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم استرجع القيم الفعالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/الرئيس ولا في الإعدادات العامة؟**

يُحدد القيمة الفعالة عبر آلية القيم الافتراضية، والتي تشمل افتراضات PowerPoint و Aspose.Slides. تُصبح القيمة المحسومة جزءًا من البيانات الفعالة الحالية.

**من قيمة الخط الفعال، هل يمكنني معرفة المستوى الذي قدم الحجم أو الخط؟**

ليس مباشرة. تُعيد البيانات الفعالة القيمة النهائية فقط. لتحديد المصدر، تحقّق من القيم المحلية على مستوى الجزء، الفقرة، إطار النص، وأنماط النص على التخطيط، الرئيس، ومستوى العرض التقديمي لترى أين تظهر التعريف الصريح الأول.

**لماذا تبدو القيم الفعالة أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت بأنها النهائية (لم يُستدعَ مستوى أعلى من الوراثة). في هذه الحالة تتطابق القيمة الفعالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعالة، ومتى أكتفي بالخصائص المحلية فقط؟**

استخدم البيانات الفعالة عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق كل الوراثات، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا أردت حفظ تلك القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تحتاج لتعديل التنسيق في مستوى معين، عدل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة البيانات الفعالة للتحقق من النتيجة.