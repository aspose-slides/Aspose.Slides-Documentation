---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية في .NET
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- إزاحة الشكل
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لـ .NET بحساب وتطبيق خصائص الشكل الفعّالة لتقديم عرض PowerPoint بدقة."
---
## **نظرة عامة**

يفسر هذا الموضوع الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق محدد، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجي على شريحة تخطيط أو شريحة رئيسية، عندما يكون لنموذج إطار النص للجزء واحد.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما تم عرضه"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها باستدعاء الطريقة `GetEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) بإطار نص وعلى الأقل جزء واحد.

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
تمثل بيانات التنسيق الفعّال التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة داخليًا، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformateffectivedata/). قد يؤدي استدعاء `GetEffective` مرة أخرى بعد تعديل التنسيق الأب أو الموروث إلى تحديث البيانات المخزنة، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعّالة لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة إلى كائن بيانات خاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم كشف كائن [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

الكود التالي يوضح كيفية الحصول على الخصائص الفعّالة للكاميرا. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لجهاز إضاءة**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم كشف كائن [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

الكود التالي يوضح كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **الحصول على الخصائص الفعّالة لإزاحة الشكل**

تسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لإزاحة الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الإزاحة الفعّالة للشكل. يتم كشف كائن [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفّر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

الكود التالي يوضح كيفية الحصول على الخصائص الفعّالة لإزاحة الجزء العلوي من الشكل. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالة.

الكود التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يُفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) بإطار نص.

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

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالة.

الكود التالي يوضح كيفية الحصول على خصائص نمط النص الفعّالة. يُفترض أن الشكل الأول على الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) بإطار نص.

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

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغيّر ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلي على مستويات مختلفة من بنية العرض التقديمي.

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

## **الحصول على تنسيق التعبئة الفعّال للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، يتم استخدام خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يُظهر الكود التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يُفترض أن الشكل الأول على الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/).

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

**هل تُعيد `GetEffective` لقطة ثابتة؟**

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالة قد تُخزن مؤقتًا داخليًا. قد تُعيد استدعاءات `GetEffective` اللاحقة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن المسترجع مسبقًا كلقطة دائمة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `GetEffective` مرة أخرى بعد تعديل التنسيق المحلي، أو أنماط الأبواب، أو تنسيق التخطيط، أو تنسيق الماستر، أو الإعدادات الافتراضية على مستوى العرض التقديمي. ستعيد المكالمة التالية تقييم شجرة التنسيق وتُعيد النتيجة الفعّالة الحالية.

**هل يؤدي تعديل أو حذف شريحة تخطيط/ماستر إلى تغيير الخصائص الفعّالة التي تم جلبها مسبقًا؟**

نعم، لكن التغيير ينعكس في مكالمة `GetEffective` التالية. إذا تم تعديل أو حذف مصدر تنسيق أبوي، قد تصبح البيانات الفعّالة التي تم الحصول عليها سابقًا قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تُعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغيّر القيم مثل الخطوط، الألوان، الأحجام أو غيرها.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. يجب إجراء التغييرات في كائنات التنسيق المحلي، ثم الحصول على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، أو في التخطيط/الماستر، أو في الإعدادات العامة؟**

يُحدَّد القيمة الفعّالة عبر آلية افتراضية تشمل إعدادات PowerPoint و Aspose.Slides الافتراضية. تُصبح تلك القيمة المحلولة جزءًا من البيانات الفعّالة الحالية.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**

ليس بشكل مباشر. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، راجع القيم المحلية عند الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، الماستر، ومستوى العرض التقديمي لمعرفة أين ظهرت التعريف الأول صراحةً.

**لماذا تبدو القيم الفعّالية أحيانًا مماثلة للقيم المحلية؟**

لأن القيمة المحلية أصبحت هي النهائية (لم يُستدع أي مستوى أعلى للوراثة). في مثل هذه الحالات تتطابق القيمة الفعّالية مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالية، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالية عندما تحتاج إلى النتيجة "كما تم عرضها" بعد تطبيق جميع الوراثات، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى حفظ هذه القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت تريد تعديل التنسيق على مستوى معين، غيّر الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالية مرة أخرى للتحقق من النتيجة.