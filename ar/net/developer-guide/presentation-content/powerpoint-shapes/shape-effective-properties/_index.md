---
title: الحصول على الخصائص الفعلية للشكل من العروض التقديمية في .NET
linktitle: خصائص فعالة
type: docs
weight: 50
url: /ar/net/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- وحدة إضاءة
- شكل بحد
- إطار نص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لـ .NET بحساب وتطبيق الخصائص الفعلية للأشكال لتحقيق عرض PowerPoint دقيق."
---
## **نظرة عامة**

هذا الموضوع يوضح الفرق بين الخصائص **المحلية** والخصائص **الفعلية**. القيم المحلية هي القيم التي يتم ضبطها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء في شريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يحتوي شكل إطار النص للجزء على واحدة.
1. إعدادات النص العامة في عرض تقديمي.

يمكن تعريف القيم المحلية أو إغفالها على أي مستوى. عندما يحتاج Aspose.Slides إلى التنسيق النهائي "كما يُعرض"، فإنه يحل سلسلة الوراثة ويعيد القيم **الفعلية**. يمكنك الحصول عليها عبر استدعاء الطريقة `GetEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعلية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
البيانات التنسيقية الفعلية تمثل التنسيق الجاري حسابه بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعلية، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformateffectivedata/)، في الذاكرة مؤقتًا. استدعاء `GetEffective` مرة أخرى بعد تعديل تنسيق الأب أو التنسيق الموروث يمكن أن يحدث تحديثًا للبيانات المخزنة، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعلية لإعادة استخدامها لاحقًا، قم بنسخ الخصائص المطلوبة مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة إلى كائن بيانات خاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعلية للكاميرا**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعلية للكاميرا. تمثل الواجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا فعلية. يتم الكشف عن مثيل [ICameraEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعلية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعلية للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى لديه تنسيق ثلاثي الأبعاد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **الحصول على الخصائص الفعلية لجهاز إضاءة**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعلية لجهاز إضاءة. تمثل الواجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز إضاءة فعلية. يتم الكشف عن مثيل [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعلية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعلية لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى لديه تنسيق ثلاثي الأبعاد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **الحصول على الخصائص الفعلية لحافة الشكل**

يسمح Aspose.Slides لك بالحصول على الخصائص الفعلية لحافة الشكل. تمثل الواجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الحافة الفعلية للشكل. يتم الكشف عن مثيل [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعلية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ithreedformat/).

يعرض مثال الشيفرة التالي كيفية الحصول على الخصائص الفعلية للحافة العليا للشكل. يفترض أن الشكل الأول في الشريحة الأولى لديه تنسيق ثلاثي الأبعاد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **الحصول على الخصائص الفعلية لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعلية لإطار النص. تحتوي الواجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعلية.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعلية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص.

```csharp
using Aspose.Slides;

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

## **الحصول على الخصائص الفعلية لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعلية لنمط النص. تحتوي الواجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعلية.

يعرض مثال الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعلية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) يحتوي على إطار نص.

```csharp
using Aspose.Slides;

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

## **الحصول على قيمة ارتفاع الخط الفعلي**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعلي. يوضح الشيفرة التالية كيف يتغير ارتفاع الخط الفعلي للجزء بعد ضبط قيم ارتفاع الخط المحلي على مستويات مختلفة من بنية العرض التقديمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **الحصول على تنسيق التعبئة الفعلي للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعلي لأجزاء مختلفة من الجدول. تحتوي الواجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعلية. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنظيم الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، يتم استعمال خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض مثال الشيفرة التالي كيفية الحصول على تنسيق التعبئة الفعلي لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/).

```csharp
using Aspose.Slides;

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

### هل تُعيد `GetEffective` لقطة ثابتة؟

ليس دائمًا. تمثل البيانات الفعلية التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعلية قد تُخزن مؤقتًا داخل النظام. قد يؤدي استدعاء `GetEffective` لاحقًا بعد تعديل تنسيق الأب أو التنسيق الموروث إلى إعادة حساب التنسيق وتحديث البيانات المخزنة، وبالتالي لا يجب اعتبار الكائن الذي تم الحصول عليه مسبقًا لقطة ثابتة.

### متى يجب قراءة الخصائص الفعلية مرة أخرى؟

استدعِ `GetEffective` مرة أخرى بعد تعديل تنسيق محلي، أو أنماط الأب، أو تنسيق التخطيط، أو تنسيق الرئيسي، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويُعيد النتيجة الفعلية الحالية.

### هل يؤثر تعديل أو حذف تخطيط/شريحة رئيسية على الخصائص الفعلية التي تم استخراجها بالفعل؟

نعم، لكن التغيير سينعكس في الاستدعاء التالي لـ `GetEffective`. إذا تم تعديل أو حذف مصدر تنسيق أب، قد تصبح البيانات الفعلية المستخرجة مسبقًا قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط والألوان والأحجام أو القيم الأخرى.

### هل يمكن تعديل القيم عبر كائنات البيانات الفعلية؟

لا. تُظهر كائنات البيانات الفعلية القيم المحسوبة فقط. قم بإجراء التعديلات في كائنات التنسيق المحلي، ثم احصل على القيم الفعلية مرة أخرى.

### ماذا يحدث إذا لم يُحدد الإعداد على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العامة؟

يتم تحديد القيمة الفعلية عبر آلية القيم الافتراضية، التي تشمل الافتراضات الخاصة بـ PowerPoint وAspose.Slides. تصبح القيمة التي تم حلها جزءًا من البيانات الفعلية الحالية.

### من قيمة الخط الفعلي، هل يمكنني معرفة المستوى الذي وفر الحجم أو الخط؟

ليس بشكل مباشر. تُعيد البيانات الفعلية القيمة النهائية. لتحديد المصدر، راجع القيم المحلية على مستوى الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، الرئيسة، ومستوى العرض التقديمي لتحديد أول تعريف صريح.

### لماذا تبدو القيم الفعلية أحيانًا مطابقة للقيم المحلية؟

لأن القيمة المحلية أصبحت هي النهائية (لم يُستدعَ مستوى أعلى من الوراثة). في هذه الحالات تتطابق القيمة الفعلية مع القيمة المحلية.

### متى يجب استخدام الخصائص الفعلية، ومتى أكتفي بالخصائص المحلية؟

استخدم البيانات الفعلية عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثات، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى الحفاظ على تلك القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت تحتاج إلى تعديل التنسيق على مستوى معين، قم بتعديل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعلية مرة أخرى للتحقق من النتيجة.