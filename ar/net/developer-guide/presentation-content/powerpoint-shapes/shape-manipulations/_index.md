---
title: إدارة أشكال العرض التقديمي في .NET
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- البحث عن شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تحديد، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وقلب أشكال العرض التقديمي باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET تمثل الأشكال داخل الشريحة كـ[IShapeCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/) مرتب. تُعد المجموعة tanto مكان العثور على الأشكال وتعديلها ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد الشكل بطريقة موثوقة، ثم يُظهر كيفية استنساخه وإزالته وإخفائه وإعادة ترتيبه. تغطي الأقسام الأخيرة تنسيق مستوى التخطيط، وتصدير SVG، والمحاذاة، وإعدادات القلب. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي تحتاجها فقط في سير عملك.

## **تحديد وإيجاد الأشكال**

تُعد فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغيّر إضافة أو إزالة أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/name/) مفيد للقوالب التي يتحكم فيها المطور ويسهل تفقده في لوحة تحديد العناصر في PowerPoint. يمكن تحرير الأسماء ولا يُضمن كونها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/alternativetext/) مفيد عندما يحدد الوصف المتاح لإمكانية الوصول أو علامة مُعطاة من قبل المؤلف الشكل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد كتابته لإمكانية الوصول، ولا يُضمن كونه فريدًا. لا تُعيد استخدام نص إمكانية الوصول ذي المعنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/officeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم بواسطة PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعد شكلًا مختلفًا ويتلقى معرفه الخاص.

خاصية [UniqueId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/uniqueid/) ذات نطاق عرض تقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي اعتبارها مفتاحًا خارجيًا دائمًا. إذا كانت هوية طويلة الأمد ضرورية، احتفظ ببيانات الربط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن `Name` بمقارنة رتبية ويُبلغ عن معرف interop ضمن نطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن ذلك بدلاً من المتابعة مع كائن غير صحيح.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

عند كون العملية خاصة بنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمّى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة مباشرة. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/insertclone/) يُنشئ نسخة أيضًا لكنه يضعها في فهرس z-order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تشمل العرض والارتفاع يمكنها تعديل الحجم أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى الأمام، ويُدرج نسخة ثانية في الخلف. لا تُغيّر التعديلات على أي نسخة الشكل الأصلي.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد المستخدمة بواسطة الأشكال المعقدة يديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/remove/) يُحذف كائن الشكل المحدد من مجموعته. عند إزالة تطابقات متعددة أثناء التكرار المفهرس، يجب المرور من النهاية لضمان بقاء الفهارس المتبقية صالحة.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ `slide.Shapes[i]`، وليس عنصر مجموعة ثابت، ولا يُحوّل الشكل بصورة غير ضرورية.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع أيضًا في الاعتبار الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ قد يغيّر إزالة شكل مرئي أكثر من مجرد مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/hidden/) على `true` يبقى الشكل في المجموعة لكنه يمنعه من الظهور في العرض التلقائي العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا يُعد الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `Count - 1` هو الأمام.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

المستطيل يُنشأ أولًا ويقع في البداية خلف الشكل البيضاوي. نقلُه إلى الفهرس النهائي يضعه في المقدمة. احرص على إكمال ترتيب z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر جديدة قد تُغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، وشرائح القالب لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل الموجود في شريحة عادية في نفس الموقع. فحص أشكال التخطيط يكون ضروريًا عندما تحتاج إلى فهم أو تغيير تنسيق مُزوَّد من قِبل التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/fillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/lineformat/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

تحرير التخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل التخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/writeassvg/) يكتب محتوى شكل مُحَدد إلى تدفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بأكملها أو الأشكال المجاورة.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

احتفظ بالعرض التقديمي مفتوحًا أثناء التصيير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلاً من شكل فردي. المتصل يمتلك التدفق ويجب عليه تحريره.

## **محاذاة الأشكال**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/alignshapes/) يوفّر تحميلات لمحاذاة جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapesalignmenttype/) يحدد الحافة أو الخط المركزي أو وضعية التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المختارة بالنسبة لبعضها البعض.

هذا المثال يُحاذي ثلاثة أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الأشكال المرتجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

المحاذاة تغيّر المواقع، لا ترتيب Z. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو الرأسي عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeframe/) تخزن الموقع، والحجم، وإعدادات القلب الأفقية والعمودية، والدوران. قيم `FlipH` و`FlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/): `True` يُفعِّل القلب، `False` يُعطِّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مُقَلَّب.

![الشكل قبل القلب](shape_to_be_flipped.png)

المثال يُحافظ على كل قيم الإطار الأخرى ويستبدل إعدادات القلب فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/frame/) جديد يستبدل الإطار بالكامل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

الشكل المُحفَظ يُعكَّس أفقيًا وعموديًا مع الحفاظ على موقعه وحجمه ودورانه.

![الشكل بعد القلب](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد `Name` أو `AlternativeText` بعد تصديقهما للقوالب المُنشأة، أو `OfficeInteropShapeId` للعمل مع interop ضمن نطاق الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة بنفس الفهرس. يمكن العثور عليه، وإعادة ترتيبه، وتعديله، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`AddClone` يضيف النسخة إلى نهاية المجموعة، وهي مقدمة ترتيب Z. استخدم `InsertClone` لاختيار الفهرس الأولي أو `Reorder` بعد إضافة جميع الأشكال.