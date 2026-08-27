---
title: إدارة أشكال العروض التقديمية في .NET
linktitle: معالجة الشكل
type: docs
weight: 40
url: /ar/net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل التفاعلي
- النص البديل للشكل
- نقطة تعديل الشكل
- تعديل الشكل المسبق
- هندسة الشكل
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
description: "تعلم كيفية تحديد، تعديل، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وقلب أشكال العروض التقديمية باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

يمثل Aspose.Slides for .NET الأشكال على الشريحة كـ[IShapeCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/). المجموعة هي المكان الذي تجد فيه وتعدل الأشكال وكذلك مصدر ترتيب تكدسها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

يتبع هذا المقال النموذج المذكور. يشرح أولاً كيفية تحديد شكل بشكل موثوق وتعديل نقاط تعديل الشكل المسبق، ثم يوضح كيفية استنساخ، إزالة، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيقات مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات القلابة. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي يحتاجها سير العمل الخاص بك فقط.

## **تحديد وإيجاد الأشكال**

مؤشرات المجموعة مفيدة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغير إضافة أو إزالة أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/name/) مفيدة للقوالب التي يتحكم فيها المطور وسهلة الفحص في لوحة اختيار PowerPoint. يمكن تعديل الأسماء ولا يُضمن تفردها، لذا ضع convention لتسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/alternativetext/) مفيدة عندما يكون وصف إمكانية الوصول أو وسمة مقدمة من المؤلف تحدد الشكل بالفعل. إنها مرئية للمستخدمين، قد تُترجم أو تُعاد صياغتها لإمكانية الوصول، ولا يُضمن تفردها. لا تعيد توجيه نص إمكانية وصول ذي معنى كمفتاح قاعدة بيانات.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/officeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المُعاد إنشاؤه هو شكل مختلف ويتلقى معرفًا خاصًا به.

خاصية [UniqueId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/uniqueid/) ذات نطاق العرض التقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي معاملتها كمفتاح خارجي دائم. إذا كانت الهوية طويلة الأمد ضرورية، احتفظ بالتطابق في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن `Name` بمقارنة ترتيبيّة ويُبلغ عن معرف الـ interop على مستوى الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلًا من الاستمرار مع الكائن الخطأ.

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

عندما تكون العملية خاصة بنوع شكل ما، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يحدّث النص والنص البديل فقط إذا كان الكائن المسمّى هو [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/).

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

## **تحديد وتعديل تعديلات الشكل المسبق**

يمكن للأشكال الهندسية المسبقة أن تُظهر نقاط تعديل تتحكم في ميزات مثل حجم الزاوية، نسب السهم، أو زوايا القوس. وصل إليها عبر مجموعة [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/adjustments/) للقراءة فقط. المجموعة نفسها تُقدَّم من قبل الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/net/aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر التعديلات وتفحص خاصية [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/type/) للقراءة فقط، التي تصف قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeadjustmenttype/) ما يتحكم به التعديل. خاصية [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/name/) للقراءة فقط توفر معلومات تعريف إضافية وتكون مفيدة خاصةً عندما يحتوي المسبق على أكثر من تعديل من نفس النوع الدلالي.

استخدم خاصية القيمة التي تتطابق مع معنى التعديل:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [RawValue](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | سمك ذيل السهم | `RawValue` |
| `ArrowheadLength` | طول رأس السهم | `RawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `RawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [AngleValue](https://reference.aspose.com/slides/ar/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `AngleValue` |

`Type` و `Name` لا يمكن تعيينهما. `RawValue` هو عدد صحيح للقراءة/الكتابة بوحدات الهندسة الأصلية للمسبق، بينما `AngleValue` هو زاوية للقراءة/الكتابة بالدرجات. عدد، ترتيب، معنى، والنطاق الصالح للتعديلات يعتمد على [ShapeType](https://reference.aspose.com/slides/ar/net/aspose.slides/igeometryshape/shapetype/) للمسبق. القيمة الصالحة لمسبق قد تكون غير صالحة أو لها تأثير مختلف في آخر.

عندما يكون `Type` هو `ShapeAdjustmentType.Custom`، لا يتعرف API على معنى دلالي قياسي. فحص `Name`، نوع المسبق، والقيمة الحالية، واترك التعديل دون تغيير ما لم تكن المعنى والنطاق معروفين. حتى للأنواع المعترف بها، تحقق مما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. توضح مقالة [Connector](/slides/ar/net/connector/) هذا الوضع مع تعديلات انحناء الموصل.

المثال الكامل التالي ينشئ إصدارات افتراضية ومعدلة لثلاثة أشكال مسبقة. يكرر عبر كل تعديل، يُبلغ عن `Name` و `Type`، يغيّر القيم المتعلقة بالحجم عبر `RawValue`، ويغيّر الزوايا عبر `AngleValue`، ثم يحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المعدل، والسهم رباعي الاتجاهات، والفطيرة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// يضيف رؤوسًا لأعمدة الشكل الافتراضي والمعدل.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

التحقق من النوع الدلالي قبل تغيير قيمة يجعل الكود صريحًا بشأن هدفه ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب على المجموعة مباشرة. إذا غيَّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addclone/) ينشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/insertclone/) يخلق نسخة أيضًا لكنه يضعها عند فهرس z-order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات مع العرض والارتفاع يمكنها تغيير حجمه أيضًا.

المثال ينشئ شريحة مقصد، يستنسخ مستطيل معنّى إلى الأمام، ويُدخل نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدّل الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقدة تُديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بهوية شكل جديدة.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء التكرار المفهرس، تجول من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ `slide.Shapes[i]`، ليس عنصر مجموعة ثابت، ولا يقوم بتحويل الشكل دون ضرورة.

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

بعد الإزالة، يتغير عدد الأشكال وفهارس الأشكال اللاحقة. المراجع إلى الأشكال غير المتأثرة تظل أكثر موثوقية من الفهارس المحفوظة. اعتبر أيضًا الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغير أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/hidden/) إلى `true` يبقي الشكل في المجموعة لكن يمنعه من الظهور في العرض العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا nor أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهارُه مرة أخرى من قبل المستخدم أو الكود، وهو يظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم وفقًا لترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/reorder/) يحرك شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `Count - 1` هو الأمام.

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

يتم إنشاء المستطيل أولاً ويقع في البداية خلف الإهليلج. نقله إلى الفهرس النهائي يجعله في المقدمة. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال المرتبطة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تغير التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، وشرائح الرئيس لها مجموعات أشكال منفصلة. الشكل الموجود في مجموعة تخطيط ليس هو نفسه الشكل الموجود في شريحة عادية بنفس الموقع. فحص أشكال التخطيط ضروري عندما تحتاج إلى فهم أو تغيير التنسيق الذي توفره التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/fillformat/) و [LineFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/lineformat/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت شريحة عادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/writeassvg/) يكتب محتوى شكل واحد مُصوَّر إلى تدفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة كاملة ولا الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. الناتج يعتمد على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدِّر الشريحة بدلاً من شكل فردي. المتصل يملك التدفق ويجب أن يُحرره.

## **محاذاة الأشكال**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/alignshapes/) لديها تحميلات تُحاذِي إما جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/net/aspose.slides/shapesalignmenttype/) يحدد الحافة، الخط المركزي، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المحددة بالنسبة لبعضها.

هذا المثال يحاذِي ثلاثة أشكال إلى الحافة العليا للشفرة. مراجع الأشكال المرتجعة تُحوَّل إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تحتاج إلى شكلين على الأقل، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد المسافات. أعِد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات القلابة الأفقية والرأسية، والدوران. قيمتي `FlipH` و `FlipV` تستخدمان [NullableBool](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/): `True` تفعّل القلابة، `False` تعطلها، و `NotDefined` تحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![الشكل قبل القلابة](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل فقط إعدادات القلابة الاثنين. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/frame/) جديد يستبدل الإطار بالكامل.

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

الشكل المحفوظ يُظهر انعكاسًا أفقيًا ورأسيًا مع الحفاظ على موقعه، حجمه، ودورانه.

![الشكل بعد القلابة](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب علي استخدام فهرس مجموعة كمعرف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يفضَّل الاعتماد على `Name` أو `AlternativeText` في القوالب المُصمَّمة، أو `OfficeInteropShapeId` للأعمال التي تتطلب تفاعلًا مع PowerPoint.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة في نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهارُه مرة أخرى.

**لماذا ظهر شكل مستنسخ أمام شكل آخر؟**

`AddClone` يضيف النسخة إلى نهاية المجموعة، وهي أمامية في ترتيب Z. استخدم `InsertClone` لاختيار الفهرس الأولي أو `Reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد تعديل شكل مسبق؟**

فقط بعد التحقق من المسبق المحدد وتخطيط المجموعة بدقة. يفضَّل التكرار عبر `IGeometryShape.Adjustments` وفحص `IAdjustValue.Type`؛ استخدم `IAdjustValue.Name` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.